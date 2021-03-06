﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    class ServiceClient
    {
        internal async static Task<List<string>> GetCategoryNameAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/Product/GetCategory/"));
        }

        internal async static Task<clsProducts> GetCategoryAsync(string prCategoryName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsProducts>
            (await lcHttpClient.GetStringAsync("http://localhost:60064/api/Product/GetCategory?Name=" + prCategoryName));

        }

        internal async static Task<List<string>> GetProductNameAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/Product/GetProduct/"));
        }

        internal async static Task<clsProducts> GetProductAsync(string prProductName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsProducts>
            (await lcHttpClient.GetStringAsync("http://localhost:60064/api/Product/GetProduct?Name=" + prProductName));

        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<string> UpdateCategoryAsync(clsCategory _Category)
        {
            return await InsertOrUpdateAsync(_Category, "http://localhost:60064/api/Product/PutCategoryWork", "PUT");
        }

        internal async static Task<string> InsertCategoryAsync(clsCategory _Category)
        {
            return await InsertOrUpdateAsync(_Category, "http://localhost:60064/api/Product/PostCategory", "POST");
        }

        internal async static Task<string> InsertProductAsync(clsProducts prProducts)
        {
            return await InsertOrUpdateAsync(prProducts, "http://localhost:60064/api/Product/PostProduct", "POST");
        }

        internal async static Task<string> UpdateProductAsync(clsProducts prProducts)
        {
            return await InsertOrUpdateAsync(prProducts, "http://localhost:60064/api/Product/PutProduct", "PUT");
        }

        internal async static Task<string> DeleteCategoryAsync(clsCategory prCategory)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
            ($"http://localhost:60064/api/Product/DeleteACategory?WorkName={prCategory.CategoryName}&ProductName={prCategory.CategoryName}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }

        }

        internal async static Task<string> DeleteProductAsync(string prName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
            ($"http://localhost:60064/api/Product/DeleteAProduct?Name={prName}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
            throw new NotImplementedException();
        }
    }
}
