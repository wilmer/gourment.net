using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PCM.Cocina.WebApp.Common.HtmlHelpers
{
    public static class DropDownListHelper
    {
        public static MvcHtmlString DisableNonSelectedDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, SelectList list, string optionLabel, object htmlAttributes, bool disableNonSelected)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            string name = ExpressionHelper.GetExpressionText((LambdaExpression)expression);
            return CustomDropdownList(htmlHelper, metadata, name, optionLabel, list, "", HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), disableNonSelected);
        }

        private static MvcHtmlString CustomDropdownList(this HtmlHelper htmlHelper, ModelMetadata metadata, string name, string optionLabel, SelectList list, string selectedValue, IDictionary<string, object> htmlAttributes, bool disableNonSelected)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            if (String.IsNullOrEmpty(fullName))
                throw new ArgumentException("name");

            object defaultValues = GetModelStateValue(htmlHelper, fullName, typeof(string));

            if (defaultValues == null && !String.IsNullOrEmpty(name))
            {
                if (metadata != null)
                    defaultValues = metadata.Model;
            }

            IEnumerable<string> values = new string[] { Convert.ToString(defaultValues, CultureInfo.CurrentCulture) };
            HashSet<string> hashValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);

            string disabledText = "";
            if (disableNonSelected && hashValues.Count > 0)
                disabledText = "disabled";

            TagBuilder dropdown = new TagBuilder("select");
            dropdown.GenerateId(name);
            dropdown.MergeAttribute("name", name);

            StringBuilder options = new StringBuilder();

            if (optionLabel != null)
                options = options.Append("<option value='" + String.Empty + "' " + disabledText + ">" + optionLabel + "</option>");

            foreach (var item in list)
            {
                item.Selected = (item.Value != null) ? hashValues.Contains(item.Value) : false;

                if (item.Selected)
                    options = options.Append("<option value='" + item.Value + "' selected>" + item.Text + "</option>");
                else
                    options = options.Append("<option value='" + item.Value + "' " + disabledText + " >" + item.Text + "</option>");
            }
            dropdown.InnerHtml = options.ToString();
            dropdown.MergeAttributes(htmlAttributes);
            dropdown.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));
            if (disableNonSelected)
            {
                if (!dropdown.Attributes.ContainsKey("readonly") && hashValues.Count > 0)
                    dropdown.MergeAttribute("readonly", "readonly");
            }

            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }

        private static IEnumerable<SelectListItem> GetSelectListWithDefaultValue(IEnumerable<SelectListItem> selectList, object defaultValue)
        {
            IEnumerable defaultValues = new[] { defaultValue };

            IEnumerable<string> values = from object value in defaultValues
                                         select Convert.ToString(value, CultureInfo.CurrentCulture);

            // ToString() by default returns an enum value's name.  But selectList may use numeric values.
            IEnumerable<string> enumValues = from Enum value in defaultValues.OfType<Enum>()
                                             select value.ToString("d");
            values = values.Concat(enumValues);

            HashSet<string> selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
            List<SelectListItem> newSelectList = new List<SelectListItem>();

            foreach (SelectListItem item in selectList)
            {
                item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                newSelectList.Add(item);
            }
            return newSelectList;
        }

        private static object GetModelStateValue(HtmlHelper htmlHelper, string key, Type destinationType)
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