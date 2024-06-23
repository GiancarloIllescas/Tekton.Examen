using Newtonsoft.Json;
using Tekton.Examen.Application.Interface.Persistence;
using Tekton.Examen.Cross.Common;
using Tekton.Examen.Domain.Entity;
using Tekton.Examen.Persistence.Data;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tekton.Examen.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly string _filePath = "products.json";

        public ProductRepository()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        private async Task<List<Product>> ReadProductsFromFileAsync()
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        private async Task WriteProductsToFileAsync(List<Product> products)
        {
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, json);
        }

        private List<Product> ReadProductsFromFile()
        {
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        private void WriteProductsToFile(List<Product> products)
        {
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllTextAsync(_filePath, json);
        }

        public Product GetById(int id)
        {
            var product = ReadProductsFromFile();
            return product.FirstOrDefault(p => p.ProductId == id);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await ReadProductsFromFileAsync();
            return product.FirstOrDefault(p => p.ProductId == id);
        }

        public bool Insert(Product product)
        {
            var products = ReadProductsFromFile();
            products.Add(product);
            WriteProductsToFile(products);
            return true;
        }

        public async Task<bool> InsertAsync(Product product)
        {
            var products = await ReadProductsFromFileAsync();
            products.Add(product);
            await WriteProductsToFileAsync(products);
            return true;

        }

        public bool Update(Product product)
        {
            var products = ReadProductsFromFile();
            var existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                products.Remove(existingProduct);
                products.Add(product);
                WriteProductsToFile(products);
            }

            return true;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var products = await ReadProductsFromFileAsync();
            var existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                products.Remove(existingProduct);
                products.Add(product);
                await WriteProductsToFileAsync(products);
            }

            return true;
        }
    }
}