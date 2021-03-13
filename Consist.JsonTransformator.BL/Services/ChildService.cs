using System.Collections.Generic;
using Consist.JsonTransformator.DAL;
using Consist.JsonTransformator.DAL.DataModels;
using Consist.JsonTransformator.PL.Entities;

namespace Consist.JsonTransformator.BL.Services
{
    public class ChildService
    {
        private readonly ChildDalService _childDalService;

        public ChildService(ChildDalService childDalService)
        {
            _childDalService = childDalService;
        }

        public void Insert(Child child)
        {
            _childDalService.Create(child);
        }
    }
}