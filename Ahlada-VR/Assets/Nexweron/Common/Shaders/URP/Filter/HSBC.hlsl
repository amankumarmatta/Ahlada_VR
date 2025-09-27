// range(0, 360)
float3 ApplyHue(float3 rgb, float value) {
    float angle = radians(value);
    float3 k = float3(0.57735, 0.57735, 0.57735);
    float cosAngle = cos(angle);
    return rgb*cosAngle + cross(k, rgb)*sin(angle) + k*dot(k, rgb)*(1 - cosAngle);
}

// range(-1, 1)
float3 ApplySaturation(float3 rgb, float value) {
    float3 v = dot(rgb, float3(0.299, 0.587, 0.114));
    float t = 2*value + abs(value) + 1;
    rgb = lerp(v, rgb, t);
    return rgb;
}

// range(-1, 1)
float3 ApplyBrightness(float3 rgb, float value) {
    rgb *= 2*value + abs(value) + 1;
    return rgb;
}

// range(-1, 1)
float3 ApplyContrast(float3 rgb, float value) {
    rgb = (rgb - 0.5f) * (value + 1) + 0.5f;
    return rgb;
}

// SHADER GRAPH
void ApplyHue_float(float3 base, float value, out float3 result) {
    result = ApplyHue(base, value);
}

void ApplyHue_float(float4 base, float value, out float4 result) {
    result = float4(ApplyHue(base.rgb, value), base.a);
}

void ApplySaturation_float(float3 base, float value, out float3 result) {
    result = ApplySaturation(base, value);
}

void ApplySaturation_float(float4 base, float value, out float4 result) {
    result = float4(ApplySaturation(base.rgb, value), base.a);
}

void ApplyBrightness_float(float3 base, float value, out float3 result) {
    result = ApplyBrightness(base, value);
}

void ApplyBrightness_float(float4 base, float value, out float4 result) {
    result = float4(ApplyBrightness(base.rgb, value), base.a);
}

void ApplyContrast_float(float3 base, float value, out float3 result) {
    result = ApplyContrast(base, value);
}

void ApplyContrast_float(float4 base, float value, out float4 result) {
    result = float4(ApplyContrast(base.rgb, value), base.a);
}
