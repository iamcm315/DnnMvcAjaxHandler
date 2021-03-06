# What is this ?

dnn mvc module not support Mvc Ajax and this make every thing hard to implement and jquery make us angry !
with this library we can use Ajax.ActionLink and BeginForm and Pagination and ... in dnn mvc module

# Install via NuGet

To install DnnMvcAjaxHandler, run the following command in the Package Manager Console
```code
pm> Install-Package DnnMvcAjaxHandler
```
You can also view the [package page](https://www.nuget.org/packages/DnnMvcAjaxHandler/) on NuGet.


# How to use ?

1) install package via nuget.
2) add refrence to style and script files at Scripts/dnnAjaxHandler path to your layout cshtml.
3) add  DnnMvcAjaxHandle namespace to view.
4) use AjaxHandler class and call its methods like BeginForm and ActionLink and PagedListPager and CheckedChange.
5) add this 2 lines to your layout
```code
    <input type="hidden" value="@Dnn.ModuleContext.ModuleId" id="dnn-module-id" />
    <input type="hidden" value="@Dnn.ModuleContext.TabId" id="dnn-module-tab-id" />
```
BeginForm 
-------------------
to submit form you must implement html like bellow that have container with an id then pass that id to BeginForm:
```code
<div id="search-form" class="form-inline">
            <div class="form-group">
                @AjaxHandler.CheckedChange(selected: false, linkText: "Ajax click me", actionName: "AddUserToRole", controllerName: "home", routeValues: new { userId = 1, roleId = 2 }, ajaxOption:
                    new AjaxHandlerOption
                    {
                        LoadingElementId = "#global-ajax-loading",
                        OnSuccess = "showMsg",
                    }, htmlAttributes: new { @class = "" })
            </div>
            <div class="form-group">
                <input class="form-control" type="text" name="term" value="" placeholder="search ..." />
            </div>
            <div class="form-group">
                @Html.DropDownList("SortBy", null, new { @class = "form-control" })
            </div>
            <div class="form-group">
                @Html.DropDownList("SortOrder", null, new { @class = "form-control" })
            </div>
            <div class="form-group">
                @AjaxHandler.BeginForm(btnText: "Search", actionName: "search", controllerName: "home",
                  ajaxOption: new AjaxHandlerOption
                  {
                      UpdateElementId = "#ajax-show-list",
                      TargetFormId = "#search-form",
                      LoadingElementId = "#global-ajax-loading",


                  }, htmlAttributes: new { @class = "btn btn-primary" })
            </div>
        </div>
```


ActionLink
-------------------
just need to use ActionLink with needed parameter like this :

```code
   @AjaxHandler.ActionLink(linkText: "delete", actionName: "delete", controllerName: "home", routeValues: new { id = item.Id }, ajaxOption:
                                                 new AjaxHandlerOption
                                                 {
                                                     FadeColor = "#dc1821",
                                                     LoadingElementId = "#global-ajax-loading",
                                                     OnSuccess = "deleteRaw",
                                                     OnConfirm = "are you sure ?",
                                                     ClickedItemId = item.Id,
                                                 },
                                                 htmlAttributes: new { @class = "btn btn-danger btn-xs" })
```

PagedListPager
-------------------
for use pagination need to read pagedList library from [here](https://github.com/hamed-shirbandi/MvcPagedList)
then we need to implement partial for pagination like bellow:
```code
@inherits DotNetNuke.Web.Mvc.Framework.DnnWebViewPage
@using DnnMvcAjaxHandler;

@AjaxHandler.PagedListPager(actionName: "search", controllerName: "home",
    routeValues: new
    {
        term = Request.QueryString["term"],
        sortOrder = Request.QueryString["sortOrder"],
        sortBy = Request.QueryString["sortBy"],

    },
    ajaxOption: new AjaxHandlerOption
    {
        UpdateElementId = "#ajax-show-list",
        LoadingElementId = "#global-ajax-loading",


    },
    pagerOptions: new PagerOptions
    {
        currentPage = (int)ViewBag.CurrentPage,
        PageCount = (int)ViewBag.PageSize,
        TotalItemCount = (int)ViewBag.TotalItemCount,
        DisplayMode = PagedListDisplayMode.IfNeeded,
        DisplayPageCountAndCurrentLocation = true,
        DisplayTotalItemCount = true,
        LinkToNextPageFormat = "next",
        LinkToPreviousPageFormat = "prev",
        CurrentLocationFormat = "page",
        PageCountFormat = "of",
        TotalItemCountFormat = "total count",
        WrapperClasses = "text-center",

    }
        )



```
CheckedChange
-------------------
this render checkbox with ajax click handler for us.
just need to use CheckedChange with needed parameter like this :

```code
        @AjaxHandler.CheckedChange(selected: false, linkText: "Ajax click me", actionName: "AddUserToRole", controllerName: "home", routeValues: new { userId = 1, roleId = 2 }, ajaxOption:
                    new AjaxHandlerOption
                    {
                        LoadingElementId = "#global-ajax-loading",
                        OnSuccess = "showMsg",
                    }, htmlAttributes: new { @class = "" })
```
# Scrennshots
![alt text](https://github.com/hamed-shirbandi/DnnMvcAjaxHandler/blob/master/DnnMvcAjaxHandlerExample/Content/img/screenShots/Screenshot-1.png)
![alt text](https://github.com/hamed-shirbandi/DnnMvcAjaxHandler/blob/master/DnnMvcAjaxHandlerExample/Content/img/screenShots/Screenshot-2.png)
![alt text](https://github.com/hamed-shirbandi/DnnMvcAjaxHandler/blob/master/DnnMvcAjaxHandlerExample/Content/img/screenShots/Screenshot-3.png)
