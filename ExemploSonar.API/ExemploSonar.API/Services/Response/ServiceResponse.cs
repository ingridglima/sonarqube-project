using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExemploSonar.API.Services.Response
{
    public class ServiceResponse<T> where T : class
    {
        [JsonIgnore]
        public T ResponseData { get; private set; }

        public Dictionary<string, string> Erros { get; private set; }

        public ServiceResponse()
        {
            Erros = new Dictionary<string, string>();
        }

        public void AddError(string errorTipo, string errorMsg)
        {
            Erros.Add(errorTipo, errorMsg);
        }

        public void SetResponseData(T entity)
        {
            ResponseData = entity;
        }

        public bool HasErrors()
        {
            return Erros.Count > 0;
        }
    }
}
