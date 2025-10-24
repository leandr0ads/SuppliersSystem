using System.Net.Http.Headers;
using System.Net.Http.Json;
using SuppliersPortal.Models;

namespace SuppliersPortal.Services;

public class SuppliersApiClient
{
    private readonly HttpClient _http;

    public SuppliersApiClient(IConfiguration config)
    {
        var baseUrl = config["SuppliersApi:BaseUrl"] ?? throw new ArgumentNullException("SuppliersApi:BaseUrl");
        _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
    }

    public void SetBearerToken(string token)
    {
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    // 📦 SUPPLIERS
    public async Task<IEnumerable<SupplierDto>> GetSuppliersAsync()
        => await _http.GetFromJsonAsync<IEnumerable<SupplierDto>>("api/suppliers") ?? [];

    public async Task<SupplierDto?> CreateSupplierAsync(CreateSupplierRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/suppliers", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SupplierDto>();
    }

    // 📦 PRODUCTS
    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        => await _http.GetFromJsonAsync<IEnumerable<ProductDto>>("api/products") ?? [];

    public async Task<ProductDto?> CreateProductAsync(CreateProductRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/products", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ProductDto>();
    }

    // 🚚 DELIVERIES
    public async Task<IEnumerable<DeliveryDto>> GetDeliveriesAsync()
        => await _http.GetFromJsonAsync<IEnumerable<DeliveryDto>>("api/deliveries") ?? [];

    public async Task<DeliveryDto?> RegisterDeliveryAsync(RegisterDeliveryRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/deliveries", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<DeliveryDto>();
    }
}
