﻿using System.Collections.Generic;

namespace mShop.Core.Communication
{
    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get;set; }
        public ResponseErrorMessages Errors { get; set; }
    }
    public class ResponseErrorMessages
    {
        public List<string> Mensagens { get; set; }
    }
}
