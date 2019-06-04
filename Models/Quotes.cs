using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Quote.Models
{
    public class Qt
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Created_At { get; set; }

        public Qt()
        {
        }
    }
}