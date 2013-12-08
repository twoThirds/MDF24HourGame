// Set at effect load
float4x4 View;
float4x4 Projection;
float4x4 World;

// Set at rendering momement
texture Texture;

float2 SheetSize;
float2 SpriteLocation;
float2 SpriteSize;

sampler TextureSampler = sampler_state
{
	Texture = <Texture>;

	MinFilter = ANISOTROPIC;
	MagFilter = ANISOTROPIC;
	MipFilter = LINEAR;

	AddressU = Clamp;
	AddressV = Clamp;
};

struct VertexShaderInput
{
    float4 Position : POSITION0;
	float2 TextureCoordinates : TEXCOORD0;
};

struct VertexShaderOutput
{
    float4 Position : POSITION0;
	float2 TextureCoordinates : TEXCOORD0;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
    VertexShaderOutput output;

    float4 worldPosition = mul(input.Position, World);
    float4 viewPosition = mul(worldPosition, View);

    output.Position = mul(viewPosition, Projection);
	//output.TextureCoordinates.x = ((SpriteSize.x / SheetSize.x) * 1) + (input.TextureCoordinates.x / 3);
	output.TextureCoordinates.x = ((1 / SheetSize.x) * SpriteLocation.x) + (input.TextureCoordinates.x / (SheetSize.x / SpriteSize.x));
	output.TextureCoordinates.y = input.TextureCoordinates.y;
	output.TextureCoordinates = ((1 / SheetSize) * SpriteLocation) + (input.TextureCoordinates / (SheetSize / SpriteSize));

    return output;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	return tex2D(TextureSampler, input.TextureCoordinates);
}

technique AnimatedQuad
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 VertexShaderFunction();
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
