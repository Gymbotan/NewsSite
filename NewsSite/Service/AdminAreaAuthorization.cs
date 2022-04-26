using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Service
{
    /// <summary>
    /// Admin authorization class.
    /// </summary>
    public class AdminAreaAuthorization : IControllerModelConvention
    {
        private readonly string area;
        private readonly string policy;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminAreaAuthorization"/> class.
        /// </summary>
        /// <param name="area">Area where admin has access.</param>
        /// <param name="policy">Authorization policy.</param>
        public AdminAreaAuthorization(string area, string policy)
        {
            this.area = area;
            this.policy = policy;
        }

        /// <summary>
        /// If a controller has AreaAttributes, we add Filter to the controller. In that case - AuthorizeFilter.
        /// </summary>
        /// <param name="controller">Controller.</param>
        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(a =>
                a is AreaAttribute && (a as AreaAttribute).RouteValue.Equals(area, StringComparison.OrdinalIgnoreCase))
                || controller.RouteValues.Any(r =>
                r.Key.Equals("area", StringComparison.OrdinalIgnoreCase) && r.Value.Equals(area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(policy));
            }
        }
    }
}
