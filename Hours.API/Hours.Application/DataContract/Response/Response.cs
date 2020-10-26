using Hours.Application.DataContract.Response.Base;
using System.Collections.Generic;

namespace Hours.Application.DataContract.Response
{
    public class Response
    {
        public  List<Base.Reports> Reports { get; set; }

        public Response()
        {
            Reports = new List<Reports>();
        }

        public Response(List<Reports> reports)
        {
            Reports = reports;
        }

        public Response(Reports report) : this(new List<Reports>() { report })
        {
      
        }

        public static Response<T> Create<T> (T data)
        {
            return new Response<T>(data);
        }

        public static Response UnProcessable(List<Reports> reports)
        {
            return new Response(reports);
        }

        public static Response Success()
        {
            return new Response();
        }
    }

    public class Response <T> : Response
    {
        public T Data { get; set; }
        public Response()
        {

        }

        public Response(T data, List<Reports> reports = null) : base(reports)
        {
            Data = data;
        }
    }
}