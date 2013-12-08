// Set at effect load
float4x4 View;
float4x4 Projection;
float2 ScreenDim;

// Set at rendering momement
texture Texture;
float4x4 World;
float4 SourceRectangle;
float2 AtlasDim;

sampler TextureSampler = sampler_state
{
	Texture = <Texture>;

	MinFilter = Point;
	MagFilter = Point;
	MipFilter = Point;

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
	output.TextureCoordinates = input.TextureCoordinates;

    return output;
}

// Adjust uv coordinates so they use the correct texture from the texture atlas
float2 CalculateAtlasUV(float2 UV, float4 SourceRectangle)
{
	float2 atlasUV;

	atlasUV.x = UV.x * (SourceRectangle.z / AtlasDim.x);	// Scale uv coordinates
	atlasUV.x += SourceRectangle.x / AtlasDim.x;			// Shift (rectangle offset from left of atlas)
	atlasUV.y = UV.y * (SourceRectangle.w / AtlasDim.y);
	atlasUV.y += SourceRectangle.y / AtlasDim.y;

	return atlasUV;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	// To tile the texture so that it isn't stretched it must be tiled as a factor of the screen dimensions:
	// x = ScreenWidth / TextureWidth
	// y = ScreenHeight / TextureHeight
	float2 text = input.TextureCoordinates;
	input.TextureCoordinates.x *= ScreenDim.x / SourceRectangle.z;					// Number of tiles per row
	input.TextureCoordinates.y *= ScreenDim.y / SourceRectangle.w;					// Number of tiles per column

	float2 tile = frac(input.TextureCoordinates);
	tile = CalculateAtlasUV(tile, SourceRectangle);

	return tex2D(TextureSampler, tile);
}

technique AnimatedQuad
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 VertexShaderFunction();
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
