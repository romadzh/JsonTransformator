using System.Collections.Generic;
using System.Linq;
using Consist.JsonTransformator.DAL;
using Consist.JsonTransformator.DAL.DataModels;
using Consist.JsonTransformator.PL.Entities;

namespace Consist.JsonTransformator.BL.Services
{
    public interface IChildService
    {
        Child TransformToChild(IEnumerable<Parent> parents);
        void Insert(Child child);
    }

    public class ChildService:IChildService
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

        public Child TransformToChild(IEnumerable<Parent> parents)
        {
            var sortedByParentId = parents.OrderBy(p => p.ParentId);
            var groupedBy = sortedByParentId.GroupBy(x => x.ParentId ?? 0).ToList();

            Child child = new Child();
            foreach (var childGrouped in groupedBy)
            {
                child.Set(childGrouped);
            }

            return child;
        }
    }
}