﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Application.UseCase.Commons.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }

        public  T? Data { get; set; }

        public string? Message { get; set; }
        public IEnumerable<BaseError>? Errors { get; set; }
    }
}
