

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Text;
using System.Globalization;


namespace JqueryAjaxComboBoxHelper
{

    public static class InputExtensions
    {

        public static MvcHtmlString AjaxComboBoxFor<TModel, TProperty>
            (this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
            string dataSourceUrl,
            string captionSrcUrl
            )
        {

            
            return htmlHelper.AjaxComboBoxFor(expression, null, dataSourceUrl, captionSrcUrl, null);
        }



        public static MvcHtmlString AjaxComboBoxFor<TModel, TProperty>
            (this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
            string formUniqueName,
            string dataSourceUrl,
            string captionSrcUrl
            )
        {
            return htmlHelper.AjaxComboBoxFor(expression, formUniqueName, dataSourceUrl, captionSrcUrl, null);
        }


        public static MvcHtmlString AjaxComboBoxFor<TModel, TProperty>
            (this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
            string formUniqueName,
            string dataSourceUrl,
            string captionSrcUrl,
            object htmlAttributes
            )
        {
            return htmlHelper.AjaxComboBoxFor(expression, formUniqueName, dataSourceUrl, captionSrcUrl,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString AjaxComboBoxFor<TModel, TProperty>
            (this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
            string formUniqueName,
            string dataSourceUrl,
            string captionSrcUrl,
            IDictionary<string, object> htmlAttributes
            )
        {



            // string fieldName = ((MemberExpression)expression.Body).Member.Name;

            string fieldName = ExpressionHelper.GetExpressionText(expression);

            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(fieldName);
            
            var tagBuilder = new TagBuilder("span");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("id", fieldName);
            tagBuilder.MergeAttribute("class", "ac_area");
            /*tagBuilder.MergeAttribute("style", 
                "float: left" + 
                (tagBuilder.Attributes.ContainsKey("style") ?
                ";" + tagBuilder.Attributes["style"] : ""), true);*/








            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            object metadataValue = metadata.Model;




            string html = tagBuilder.ToString();


            var sb = new StringBuilder();



            string valueParameter = Convert.ToString(metadataValue, CultureInfo.CurrentCulture);

            // HtmlHelper h = htmlHelper;

            string attemptedValue = (string)htmlHelper.GetModelStateValue(fullName, typeof(string));
            // string initVal = attemptedValue ?? ((useViewData) ? htmlHelper.EvalString(fullName); 
            string initVal = attemptedValue ?? valueParameter;


            //// TODO for ComboBox's hidden

            //// If there are any errors for a named field, we add the css attribute.
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }


            // tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(fieldName, metadata));

            var z =
                    (from y in htmlHelper.GetUnobtrusiveValidationAttributes(fieldName, metadata)
                     select new { KeyValue = "'" + y.Key + "'" + " : " + ("'" + y.Value.ToString() + "'") })
                    .Select(x => x.KeyValue).ToArray();


            string fieldAttributes = "";
            if (z.Length > 0)
                fieldAttributes = string.Join(" , ", z);






            sb.Append(
string.Format(
@"
<script type=""text/javascript"">
$(function() {{
    
    var n = $('#{0}'{1}).ajaxComboBox('{2}', {{
        'lang' : 'en',
        'select_only' : true,
        'mini' : true,
        'init_src' : '{3}',
        'init_val' : ['{4}']
        {5}
    }});

    $.validator.unobtrusive.parseDynamicContent(n);
    
}});
</script>
", fieldName.Replace(".", @"\\.")
 , formUniqueName == null ? "" : ", $('#" + formUniqueName + "')"
 , dataSourceUrl
 , captionSrcUrl
 , initVal
 , z.Length > 0 ? (", " + "other_attr : {" + fieldAttributes + "}") : ""
 )
            );




            // return new MvcHtmlString(html + @"<span style=""float: left; margin-top: 0px""></span>"  + " " + sb.ToString());
            return new MvcHtmlString(html + sb.ToString());

            // return new MvcHtmlString(tagBuilder.ToString());


        }



    }// class


    // copied from Microsoft's code, why it's internal? // Michael Buen
    internal static class Helper
    {

        static internal object GetModelStateValue(this HtmlHelper htmlHelper, string key, Type destinationType)
        {
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(key, out modelState))
            {
                if (modelState.Value != null)
                {
                    return modelState.Value.ConvertTo(destinationType, null /* culture */);
                }
            }
            return null;
        }
    }
}