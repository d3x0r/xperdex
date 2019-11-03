//------- Constants --------
float4x4 xView;
float4x4 xProjection;
float4x4 xWorld;
float3 CameraForward;
float3 LightDirection;
float3 AmbientColor;
float AmbientPower;
float3 SpecularColor;
float SpecularPower;
float3 DiffuseColor;

//------- Texture Samplers --------
Texture xTexture;
sampler TextureSampler = sampler_state { texture = <xTexture> ; magfilter = LINEAR; minfilter = LINEAR; mipfilter=LINEAR; AddressU = mirror; AddressV = mirror;};

Texture GrassTexture;
sampler GrassTextureSampler = sampler_state { texture = <GrassTexture> ; magfilter = LINEAR; minfilter = LINEAR; 
                                                                         mipfilter=LINEAR; AddressU  = Wrap;
                                                                         AddressV  = Wrap; AddressW  = Wrap;};

Texture SandTexture;
sampler SandTextureSampler = sampler_state { texture = <SandTexture> ; magfilter = LINEAR; minfilter = LINEAR; 
                                                                       mipfilter =LINEAR; AddressU  = Wrap;
                                                                       AddressV  = Wrap; AddressW  = Wrap;};

Texture RockTexture;
sampler RockTextureSampler = sampler_state { texture = <RockTexture> ; magfilter = LINEAR; minfilter = LINEAR; 
                                                                       mipfilter = LINEAR; AddressU  = Wrap;
                                                                       AddressV  = Wrap; AddressW  = Wrap;};

Texture GrassNormal;
sampler2D GrassNormalSampler : TEXUNIT1 = sampler_state
{ Texture   = (GrassNormal); magfilter = LINEAR; minfilter = LINEAR; 
                             mipfilter = LINEAR; AddressU  = Wrap;
                             AddressV  = Wrap; AddressW  = Wrap;};

Texture SandNormal;
sampler2D SandNormalSampler : TEXUNIT1 = sampler_state
{ Texture   = (SandNormal); magfilter  = LINEAR; minfilter = LINEAR; 
                             mipfilter = LINEAR; AddressU  = Wrap;
                             AddressV  = Wrap; AddressW  = Wrap;};

Texture RockNormal;
sampler2D RockNormalSampler : TEXUNIT1 = sampler_state
{ Texture   = (RockNormal); magfilter = LINEAR; minfilter = LINEAR; 
                             mipfilter=LINEAR; AddressU  = Wrap;
                             AddressV  = Wrap; AddressW  = Wrap;};

//------- Technique: Textured --------

struct TexVertexToPixel
{
    float4 Position         : POSITION;    
    float4 Color            : COLOR0;
    float3 Normal           : TEXCOORD0;
    float4 TextureCoords    : TEXCOORD1;
    float3 LightDirection   : TEXCOORD2;
};

struct TexPixelToFrame
{
    float4 Color : COLOR0;
};

TexVertexToPixel TexturedVS( float4 inPos : POSITION, float3 inNormal: NORMAL, float4 inTexCoords: TEXCOORD0)
{
    TexVertexToPixel Output = (TexVertexToPixel)0;
    
    float4x4 preViewProjection = mul (xView, xProjection);
    float4x4 preWorldViewProjection = mul (xWorld, preViewProjection);
    
    Output.Position = mul(inPos, preWorldViewProjection);
    Output.Normal = mul(normalize(inNormal), xWorld);
    Output.TextureCoords = inTexCoords;
    Output.LightDirection = -LightDirection;
    
    return Output;    
}

TexPixelToFrame TexturedPS(TexVertexToPixel PSIn)
{
    TexPixelToFrame Output = (TexPixelToFrame)0;
    
    float lightingFactor = saturate(saturate(dot(PSIn.Normal, PSIn.LightDirection)) + AmbientPower);
        
    Output.Color = tex2D(TextureSampler, PSIn.TextureCoords) * lightingFactor;
    
    Output.Color.rgb *= SpecularColor + AmbientColor;
    Output.Color.a = 1;

    return Output;
}

technique Textured
{
    pass Pass0
    {
        VertexShader = compile vs_1_1 TexturedVS();
        PixelShader = compile ps_2_0 TexturedPS();
    }
}

//------- Technique: MultiTextured --------
 
 struct MultiTexVertexToPixel
 {
     float4 Position          : POSITION;    
     float3 Normal            : TEXCOORD0;
     float4 TextureCoords     : TEXCOORD1;     
     float3 LightDirection    : TEXCOORD2;
     float4 TerrainColorWeight: COLOR0;
     float Depth              : TEXCOORD3;
     float3 View			  : TEXCOORD4;
 };
 
 struct MultiTexPixelToFrame
 {
     float4 Color : COLOR0;
 };

 MultiTexVertexToPixel MultiTexturedVS( float4 inPos : POSITION, float4 inTexture : TEXCOORD3, float3 inNormal: NORMAL, float4 inTerrainWeights: COLOR0)    
 {
     MultiTexVertexToPixel Output = (MultiTexVertexToPixel)0;
     float4x4 preViewProjection = mul (xView, xProjection);
     float4x4 preWorldViewProjection = mul (xWorld, preViewProjection);
     
     Output.Position = mul(inPos, preWorldViewProjection);
     Output.Normal = mul(normalize(inNormal), xWorld);

     Output.TextureCoords.x = inPos.x;
     Output.TextureCoords.y = inPos.y;

     Output.LightDirection = -LightDirection;

     Output.TerrainColorWeight = inTerrainWeights;
     Output.Depth = Output.Position.z;
     float3 PosWorld = normalize(mul(inPos, xWorld));
     Output.View = -CameraForward - PosWorld;
     
     return Output;    
 }
 
 MultiTexPixelToFrame MultiTexturedPS(MultiTexVertexToPixel PSIn)
 {
     MultiTexPixelToFrame Output = (MultiTexPixelToFrame)0;
     
     float3 ViewDir = normalize(PSIn.View);
     
     float blendDistance = 75;
     float blendWidth = 50;
     float blendFactor = clamp((PSIn.Depth-blendDistance)/blendWidth, 0, 1);
   
     float lightingFactor = saturate(dot(PSIn.Normal, PSIn.LightDirection));
     
     float4 farColor;
     farColor = tex2D(SandTextureSampler, PSIn.TextureCoords)   * PSIn.TerrainColorWeight.r;
     farColor += tex2D(GrassTextureSampler, PSIn.TextureCoords) * PSIn.TerrainColorWeight.g;
     farColor += tex2D(RockTextureSampler, PSIn.TextureCoords)  * PSIn.TerrainColorWeight.b;
 
     float4 nearColor;
     float2 nearTextureCoords = PSIn.TextureCoords * 3;
     nearColor = tex2D(SandTextureSampler, nearTextureCoords)   * PSIn.TerrainColorWeight.r;
     nearColor += tex2D(GrassTextureSampler, nearTextureCoords) * PSIn.TerrainColorWeight.g;
     nearColor += tex2D(RockTextureSampler, nearTextureCoords)  * PSIn.TerrainColorWeight.b;
     
     float3 Reflect = normalize(2 * lightingFactor * PSIn.Normal - PSIn.LightDirection);
     float4 specular = pow(saturate(dot(Reflect, ViewDir)), SpecularPower);
     
     Output.Color = farColor * blendFactor + nearColor * (1 - blendFactor);

     Output.Color.rgb *= (AmbientColor + DiffuseColor * lightingFactor + specular * SpecularColor) * AmbientPower;
 
     return Output;
 }
 
 technique MultiTextured
 {
     pass Pass0
     {
         VertexShader = compile vs_1_1 MultiTexturedVS();
         PixelShader = compile ps_2_0 MultiTexturedPS();
     }
 }

//------- Technique: MultiTexturedNormaled --------
 
 struct VS_INPUT
 {
     float4 Position            : POSITION0;
     float2 TextureCoords       : TEXCOORD0;     
     float3 Normal              : NORMAL0;    
     float3 Binormal            : BINORMAL0;
     float3 Tangent             : TANGENT0;
     float4 TerrainColorWeight  : COLOR0;
 };

struct VS_OUTPUT
{
    float4 position            : POSITION0;
    float2 texCoord            : TEXCOORD0;
    float3 lightDirection      : TEXCOORD1;
    float3 viewDirection       : TEXCOORD2;
    float3x3 tangentToWorld    : TEXCOORD3;
    float3 Normal			   : TEXCOORD6;
    float4 TerrainColorWeight  : COLOR0;
};

 VS_OUTPUT MultiTexturedNormaledVS( VS_INPUT input)    
 {
     VS_OUTPUT Output;
     float4x4 preViewProjection = mul (xView, xProjection);
     float4x4 preWorldViewProjection = mul (xWorld, preViewProjection);
     
     Output.position = mul(input.Position, preWorldViewProjection);
     Output.Normal = mul(normalize(input.Normal), xWorld);

     float4 worldSpacePos = mul(input.Position, xWorld);
     
     Output.lightDirection = -LightDirection;
     
     float3 eyePosition = mul(-xView._m30_m31_m32, transpose(xView));    
     Output.viewDirection = worldSpacePos - eyePosition; 

     Output.texCoord.x = input.Position.x * .05f;
     Output.texCoord.y = input.Position.y * .05f;

     Output.TerrainColorWeight = input.TerrainColorWeight;
     
     Output.tangentToWorld[0] = mul(input.Tangent,   xWorld);
	 Output.tangentToWorld[1] = mul(input.Binormal,  xWorld);
	 Output.tangentToWorld[2] = mul(input.Normal,    xWorld);
	 
	 float3 PosWorld = normalize(mul(input.Position, xWorld));

     return Output;    
 }
 
 float4 MultiTexturedNormaledPS(VS_OUTPUT input) : COLOR0
 {
     float3 normalFromMap = (2.0f * tex2D(SandNormalSampler, input.texCoord) - 1.0f) * input.TerrainColorWeight.r;
     normalFromMap += (2.0f * tex2D(GrassNormalSampler, input.texCoord) - 1.0f) * input.TerrainColorWeight.g;
     normalFromMap += (2.0f * tex2D(RockNormalSampler, input.texCoord) - 1.0f)  * input.TerrainColorWeight.b;
     normalFromMap = mul(normalFromMap, input.tangentToWorld);
     normalFromMap = normalize(normalFromMap) * 0.5f;

     input.viewDirection = normalize(input.viewDirection);
     input.lightDirection = normalize(input.lightDirection);    

     // Factor in normal mapping and terrain vertex normals as well in lighting of the pixel
     float lightingFactor = saturate(dot(normalFromMap + input.Normal, input.lightDirection));
     
     //float reflectFactor = saturate(dot(input.Normal, input.lightDirection));

	 float4 Color;
     Color = tex2D(SandTextureSampler, input.texCoord)   * input.TerrainColorWeight.r;
     Color += tex2D(GrassTextureSampler, input.texCoord) * input.TerrainColorWeight.g;
     Color += tex2D(RockTextureSampler, input.texCoord)  * input.TerrainColorWeight.b;

     float3 Reflect = normalize(lightingFactor * input.Normal - input.lightDirection);
     float4 specular = pow(saturate(dot(Reflect, input.viewDirection)), SpecularPower);
     
	 Color.rgb *= (AmbientColor + (DiffuseColor * lightingFactor) + (SpecularColor * specular)) * AmbientPower;
 
     return Color;
 }
 
 technique MultiTexturedNormaled
 {
     pass Pass0
     {
         VertexShader = compile vs_1_1 MultiTexturedNormaledVS();
         PixelShader = compile ps_2_0 MultiTexturedNormaledPS();
     }
 }