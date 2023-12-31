﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Documents
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; } = ObjectId.Empty;

        public DateTime CreatedAt => Id.CreationTime;
    }
}
