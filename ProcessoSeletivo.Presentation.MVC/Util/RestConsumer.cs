using ProcessoSeletivo.Application.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProcessoSeletivo.Presentation.MVC.Util
{
    public class RestConsumer<TViewModel> where TViewModel : ViewModelBase, new()
    {
        public readonly string baseUrl= ConfigurationManager.AppSettings["WebServiceUrl"] + typeof(TViewModel).Name.Replace("ViewModel", "");
        private readonly RestClient client;
        public RestConsumer()
        {
            client = new RestClient(baseUrl);
        }

        public List<TViewModel> GetAll()
        {
            var req = new RestRequest("GetAll", Method.GET);
            var resp = client.Execute<List<TViewModel>>(req);

            return resp.Data;
        }

        public TViewModel GetById(int id)
        {
            var req = new RestRequest("{id}", Method.GET);
            req.AddParameter("id", id);
            var resp = client.Execute<TViewModel>(req);

            return resp.Data;
        }

        public void Add(TViewModel obj)
        {
            var req = new RestRequest(Method.POST);
            req.AddJsonBody(obj);
            var resp = client.Execute(req);

            if (resp.ErrorException != null)
            {
                throw resp.ErrorException;
            }

        }


        public void Update(TViewModel obj)
        {
            var req = new RestRequest(Method.PUT);
            req.AddJsonBody(obj);
            var resp = client.Execute(req);

            if (resp.ErrorException != null)
            {
                throw resp.ErrorException;
            }
        }


    }
}