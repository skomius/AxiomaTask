﻿using AxiomaTask.Data;
using AxiomaTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiomaTask
{
    internal class SearchResultRepository
    {
        internal SearchResult AddSearchResult(SearchResult searchResult, SearchDBContext dBContext) 
        {
            var entity = dBContext.SearchResults.Add(searchResult).Entity;
            dBContext.SaveChanges();
            return entity;
        }
    }
}
