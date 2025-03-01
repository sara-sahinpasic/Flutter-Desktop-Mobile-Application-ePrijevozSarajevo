﻿using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    public class BaseCRUDController<TModel, TSearch, TInsert, TUpdate> : BaseController<TModel, TSearch>
        where TModel : class
        where TSearch : BaseSearchObject
    {
        protected new ICRUDService<TModel, TSearch, TInsert, TUpdate> _service;
        public BaseCRUDController(ICRUDService<TModel, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual async Task <TModel> Insert(TInsert request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{id}")]
        public virtual async Task <TModel> Update(int id, TUpdate request)
        {
            return await _service.Update(id, request);
        }
        [HttpDelete("{id}")]
        public virtual async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
