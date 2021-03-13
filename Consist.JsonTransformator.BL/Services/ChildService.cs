using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consist.JsonTransformator.DAL;
using Consist.JsonTransformator.DAL.DataModels;
using Consist.JsonTransformator.PL.Entities;

namespace Consist.JsonTransformator.BL.Services
{
    public interface IChildService
    {
        /// <summary>
        /// transform flat collection to composite object
        /// </summary>
        Child TransformToChild(IEnumerable<Parent> parents);
        /// <summary>
        /// Insert the object to repository
        /// </summary>
        Task InsertAsync(Child child);
    }

    public class ChildService:IChildService
    {
        private readonly IChildDalService _childDalService;

        public ChildService(IChildDalService childDalService)
        {
            _childDalService = childDalService;
        }

        public async Task InsertAsync(Child child)
        {
            await _childDalService.CreateAsync(child);
        }

        public Child TransformToChild(IEnumerable<Parent> parents)
        {
            var sortedByParentId = parents.OrderBy(p => p.ParentId);
            var groupedBy = sortedByParentId.GroupBy(x => x.ParentId ?? 0).ToList();

            var child = new Child();
            foreach (var childGrouped in groupedBy)
            {
                child.SetChildren(childGrouped);
            }

            return child;
        }
    }
}