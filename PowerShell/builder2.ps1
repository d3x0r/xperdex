
function compile-cs-library( $target,$files,$refs,$resources )
{
	$csc=new-object Microsoft.CSharp.CSharpCodeProvider
	#$icc=$csc.CreateCompiler()

    $cpar = New-Object System.CodeDom.Compiler.CompilerParameters
    #$cpar|get-member
    $cpar.GenerateInMemory = $false

    $cpar.CompilerOptions = "-unsafe /optimize"    
    $cpar.GenerateExecutable = $false
    #$cpar.MainClass="zzy"
    $cpar.OutputAssembly = $target
    
    if($refs) { $cpar.ReferencedAssemblies.AddRange($refs) }
    if($resources) { $cpar.EmbeddedResources.AddRange($resources) }

$cpar.EmbeddedResources

    $junk=new-object "System.Collections.Generic.List``1[System.String]";
    foreach( $file in $files ) { $junk.Add( $file ) }
  
    $cr = $csc.CompileAssemblyFromFile( $cpar, $junk.ToArray() )
    
    if ( $cr.Errors.Count)
    {
        #$codeLines = $code.Split("`n");
        
        foreach ($ce in $cr.Errors)
        {
            #$ce|get-member
            #write-host "Error: $($codeLines[$($ce.Line - 1)])"
            $ce.FileName
            $ce |out-default
        }
        #Throw "INVALID DATA: Errors encountered while compiling code"
    }
    else
    {
        "build ok?"
    }
    if ( $cr.Warnings.Count)
    {
        #$codeLines = $code.Split("`n");
        
        foreach ($ce in $cr.Warnings)
        {
            #$ce|get-member
            #write-host "Error: $($codeLines[$($ce.Line - 1)])"
            $ce.FileName
            $ce |out-default
        }
        #Throw "INVALID DATA: Errors encountered while compiling code"
    }
    else
    {
        "build ok?"
    }
}

function build-cs( [string] $file )
{
    [xml]$xd = get-content $file
    $item=get-item $file
    $base_path=$item.DirectoryName
    if( $xd.project.program )
    {
    $xd.project.program.name
    $xd.project.program.sources
    $xd.project.program.refs
    }
    if( $xd.project.library )
    {
    $name=$xd.project.library.name
    if( !$name.Contains( ".dll" ) )
    {
        $name=$name+".dll";
    }
    $name="./"+$name
    #$xd.project.library.sources
    $files=foreach($file in $xd.project.library.sources.Split(" `n`t")) { 
        if( $file.Length -gt 0)  {
        $base_path +"\"+ $file; }
        };
    $refs=([string]$xd.project.library.refs).Split(" `n`t" );
    if([string]$xd.project.library.resources) {
        $resources=foreach($file in $xd.project.library.resources.Split(" `n`t")) { 
        if( $file.Length -gt 0)  {
        $base_path +"\"+ $file; }
        };
    }
    compile-cs-library  $name  $files  $refs $resources
    }
}
