float4x4 ViewMatrix;
float4x4 ReflectionView;
float4x4 ProjectionMatrix;
float4x4 WorldMatrix;
float Time;
float Reflectivity = 0.5f;
float3 sky_color;
float3 SpecularColor;
float3 AmbientColor;
float3 DiffuseColor;
float3 water_color;
float3 LightDirection;
float3 AmbientPower = 0.5f;

float WaveHeight = 0.3f;
float WaveLength = 0.1f;
float WindForce = 20.0f;
float4x4 WindDirection;

//===========================================================================

texture CubeMapTexture;
samplerCUBE CubeMapSampler = sampler_state
{  
    Texture = (CubeMapTexture); 
    MipFilter = LINEAR; 
    MinFilter = LINEAR; 
    MagFilter = LINEAR; 
    AddressU  = Wrap;
    AddressV  = Wrap; 
    AddressW  = Wrap;
};

Texture BumpTexture;
sampler2D BumpMapSampler : TEXUNIT1 = sampler_state
{ Texture   = (BumpTexture); magfilter = LINEAR; minfilter = LINEAR; 
                             mipfilter = LINEAR; AddressU  = Mirror;
                             AddressV  = Mirror; AddressW  = Mirror; };
                             
Texture ReflectionMapTexture;
sampler ReflectionSampler = sampler_state { texture = <ReflectionMapTexture> ; magfilter = LINEAR; minfilter = LINEAR; mipfilter=LINEAR; AddressU = mirror; AddressV = mirror;};

Texture RefractionMapTexture;
sampler RefractionSampler = sampler_state { texture = <RefractionMapTexture> ; magfilter = LINEAR; minfilter = LINEAR; mipfilter=LINEAR; AddressU = mirror; AddressV = mirror;};

                             
//==================================================================================                        
// TECHNIQUE: water
// This technique simply reflects a cube mapped sky texture, and has a set opacity                       

struct VS_INPUT
 {
     float4 Position            : POSITION0;
     float2 TextureCoords       : TEXCOORD0;     
     float3 Normal              : NORMAL0;    
     float3 Binormal            : BINORMAL0;
     float3 Tangent             : TANGENT0;
 };

struct VS_OUTPUT
{
    float4 Position             : POSITION0;
    float2 TextureCoords        : TEXCOORD0;
    float3 LightDirection       : TEXCOORD1;
    float3 ViewDirection        : TEXCOORD2;
    float3 Normal			    : TEXCOORD3;
    float3 Binormal			    : TEXCOORD4;
    float3 Tangent			    : TEXCOORD5;
};

VS_OUTPUT VertexShader( VS_INPUT input )
{
	VS_OUTPUT Output;
  
    float4 worldSpacePos = mul(input.Position, WorldMatrix);

    Output.LightDirection = -LightDirection;

    Output.Normal = normalize(mul(input.Normal, WorldMatrix));
    Output.Tangent = normalize(mul(input.Tangent, WorldMatrix));
    Output.Binormal = normalize(mul(input.Binormal, WorldMatrix));
    
    float3 eyePosition = mul(-ViewMatrix._m30_m31_m32, transpose(ViewMatrix));
    Output.ViewDirection = worldSpacePos - eyePosition; 
    
    Output.Position = mul(worldSpacePos, mul(ViewMatrix, ProjectionMatrix));    // transform Position    
    Output.TextureCoords = input.TextureCoords.xy;

    return Output;
} 

float4 PixelShader( VS_OUTPUT Input ) : COLOR
{        
	float3 TSBumpNormal = 2 * (tex2D(BumpMapSampler, Input.TextureCoords - 0.05 * Time) - 0.5); // fetch bump map
	float3 TSBumpNormal2 = 2 * (tex2D(BumpMapSampler, 0.01 * (Input.TextureCoords + 0.1 * Time)) - 0.5); // fetch bump map
	TSBumpNormal = normalize(TSBumpNormal + 2 * TSBumpNormal2);    

	//float3 E = normalize(Input.ViewDirection - Input.Position.xyz);    
	Input.ViewDirection = normalize(Input.ViewDirection);
    
	float3 WSBumpNormal = mul(TSBumpNormal, float3x3(Input.Tangent, Input.Binormal, Input.Normal));
	
	float lightingFactor = saturate(dot(Input.Normal, -Input.ViewDirection));
 
	//Fresnel term for light reflection/refraction ratio
	float3 R = reflect(-Input.ViewDirection, WSBumpNormal);
	float4 Cube = texCUBE(CubeMapSampler, R);

	float fresnel = clamp(pow(pow(dot(R,WSBumpNormal),0.15),2.5),0,1);
              
	float4 color;
    color.rgb = lerp(0.45 * Cube + Cube.a * 3 * lightingFactor + sky_color * lightingFactor, water_color * lightingFactor, fresnel) * AmbientPower; 
	color.a = 1.0 - (fresnel * 0.5f);
	
	return color;
} 

technique Water
{
    pass P0
    {
        VertexShader = compile vs_1_1 VertexShader();
        PixelShader = compile ps_2_0 PixelShader();
    }
}

//==================================================================================                        
// TECHNIQUE: WaterAdv
// This technique uses refraction and reflection
// CREDIT: Most of this shader was written by Riemer Grootjans, http://www.riemers.net                 

struct ADV_VS_INPUT
 {
     float4 Position            : POSITION0;
     float2 TextureCoords       : TEXCOORD0;
     float2 RefractionMap       : TEXCOORD1;     
     float2 ReflectionMap		: TEXCOORD2;
     float3 Normal              : NORMAL0;    
     float3 Binormal            : BINORMAL0;
     float3 Tangent             : TANGENT0;
 };

struct ADV_VS_OUTPUT
{
    float4 Position             : POSITION0;
    float2 TextureCoords        : TEXCOORD0;
    float3 LightDirection       : TEXCOORD1;
    float3 ViewDirection        : TEXCOORD2;
    float3 Normal			    : TEXCOORD3;
    float3 Binormal			    : TEXCOORD4;
    float3 Tangent			    : TEXCOORD5;
    float4 RefractionMap        : TEXCOORD6;     
    float4 ReflectionMap		: TEXCOORD7; 
};

ADV_VS_OUTPUT Adv_VertexShader( ADV_VS_INPUT input )
{
	ADV_VS_OUTPUT Output;
  
    float4 worldSpacePos = mul(input.Position, WorldMatrix);

    Output.LightDirection = -LightDirection;
    
    float4x4 WorldViewProjection = mul (WorldMatrix, mul(ViewMatrix, ProjectionMatrix));
    float4x4 ReflectionViewProjection = mul (ReflectionView, ProjectionMatrix);
    float4x4 WorldReflectionViewProjection = mul (WorldMatrix, ReflectionViewProjection);
   
    Output.RefractionMap = mul(input.Position, WorldViewProjection);
    Output.ReflectionMap = mul(input.Position, WorldReflectionViewProjection);

    Output.Normal = normalize(mul(input.Normal, WorldMatrix));
    Output.Tangent = normalize(mul(input.Tangent, WorldMatrix));
    Output.Binormal = normalize(mul(input.Binormal, WorldMatrix));
    
    float3 eyePosition = mul(-ViewMatrix._m30_m31_m32, transpose(ViewMatrix));
    Output.ViewDirection = worldSpacePos - eyePosition; 
    
    Output.Position = mul(worldSpacePos, mul(ViewMatrix, ProjectionMatrix));    // transform Position    
    
    float4 absoluteTexCoords = float4(input.TextureCoords, 0, 1);
    float4 rotatedTexCoords = mul(absoluteTexCoords, WindDirection);
    float2 moveVector = float2(0, 1);
    Output.TextureCoords = rotatedTexCoords.xy/WaveLength + Time*WindForce*moveVector.xy;
    
    return Output;
} 
 
float4 Adv_PixelShader( ADV_VS_OUTPUT Input ) : COLOR
{
    Input.ViewDirection = normalize(Input.ViewDirection);

	float2 ProjectedTexCoords;
    ProjectedTexCoords.x = Input.ReflectionMap.x / Input.ReflectionMap.w / 2.0f + 0.5f;
    ProjectedTexCoords.y = -Input.ReflectionMap.y / Input.ReflectionMap.w / 2.0f + 0.5f;

    float4 bumpColor = tex2D(BumpMapSampler, Input.TextureCoords);
    float2 perturbation = WaveHeight * (bumpColor.rg - 0.5f);
    float2 perturbatedTexCoords = ProjectedTexCoords + perturbation;
    float4 reflectiveColor = tex2D(ReflectionSampler, perturbatedTexCoords); 
 
    float2 ProjectedRefrTexCoords;
    ProjectedRefrTexCoords.x = Input.RefractionMap.x/Input.RefractionMap.w/2.0f + 0.5f;
    ProjectedRefrTexCoords.y = -Input.RefractionMap.y/Input.RefractionMap.w/2.0f + 0.5f;
    float2 perturbatedRefrTexCoords = ProjectedRefrTexCoords + perturbation;
    float4 refractiveColor = tex2D(RefractionSampler, perturbatedRefrTexCoords);
    
    float3 normalVector = float3(0,0,1);
    float fresnelTerm = dot(-Input.ViewDirection, normalVector);
    float4 combinedColor = (refractiveColor * fresnelTerm) + (reflectiveColor * (1 - fresnelTerm));

    float4 dullColor = float4(water_color, 1.0f);
    float dullBlendFactor = 0.2f;

    float4 color = (dullBlendFactor * dullColor) + ((1-dullBlendFactor)*combinedColor);
    return color;
}

technique WaterAdv
{
    pass P0
    {
        VertexShader = compile vs_1_1 Adv_VertexShader();
        PixelShader = compile ps_2_0 Adv_PixelShader();
    }
}