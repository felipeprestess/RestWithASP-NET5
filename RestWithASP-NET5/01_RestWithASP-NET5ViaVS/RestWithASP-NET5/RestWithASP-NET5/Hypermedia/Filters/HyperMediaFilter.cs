using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Hypermedia.Filters
{
    public class HyperMediaFilter : ResultFilterAttribute
    {
        private readonly HyperMediaFilterOptions _options;

        public HyperMediaFilter(HyperMediaFilterOptions options)
        {
            _options = options;
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            TryEnrichResult(context);
            base.OnResultExecuted(context);
        }

        private void TryEnrichResult(ResultExecutedContext context)
        {
            if (context.Result is OkObjectResult objectResult)
            {
                var enricher = _options
                    .ContentResponseEnricherList
                    .FirstOrDefault(x => x.CanEnrich(context));

                if (enricher != null) Task.FromResult(enricher.Enrich(context));
            }
        }
    }
}
