#pragma checksum "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecfb5548a191cbef1e3556d3241554f88a7cc777"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BrandCRUDclient_BrandCRUD), @"mvc.1.0.view", @"/Views/BrandCRUDclient/BrandCRUD.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BrandCRUDclient/BrandCRUD.cshtml", typeof(AspNetCore.Views_BrandCRUDclient_BrandCRUD))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\_ViewImports.cshtml"
using Brands.Web;

#line default
#line hidden
#line 2 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\_ViewImports.cshtml"
using Brands.Web.Models;

#line default
#line hidden
#line 2 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
using Brands.Core.DTOs;

#line default
#line hidden
#line 3 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
using Brands.Core.DomainName;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecfb5548a191cbef1e3556d3241554f88a7cc777", @"/Views/BrandCRUDclient/BrandCRUD.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a50f2494ecb3996fcf7933f295c01bdb83272cd", @"/Views/_ViewImports.cshtml")]
    public class Views_BrandCRUDclient_BrandCRUD : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 6 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
  
    ViewData["Title"] = "BrandCRUDclient";
    Layout = "/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(172, 36, true);
            WriteLiteral("\r\n<h2>BrandCRUDclient</h2>\r\n<br />\r\n");
            EndContext();
#line 13 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
            BeginContext(248, 29, true);
            WriteLiteral("    <a href=\"Logout\">Log Out ");
            EndContext();
            BeginContext(278, 29, false);
#line 15 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                        Write(User.Identity.Name.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(307, 8, true);
            WriteLiteral(" !</a>\r\n");
            EndContext();
#line 16 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
}

#line default
#line hidden
            BeginContext(318, 100, true);
            WriteLiteral("<br />\r\n\r\n<div id=\"cssReference4MessageBox\"></div>\r\n\r\n<div id=\"dialog_Edit\" title=\"Attention\">\r\n    ");
            EndContext();
            BeginContext(418, 559, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "68f094cf7bc64197812a1843007f9fcd", async() => {
                BeginContext(424, 546, true);
                WriteLiteral(@"
        <p>If you want to edit this item , please insert its new features!</p><br>
        <p>Persian brand name: </p>
        <input type=""text"" id=""_PersianName4Edit"" name=""PersianName4Edit""><br>
        <p>English brand name : </p>
        <input type=""text"" id=""_EnglishName4Edit"" name=""EnglishName4Edit""><br>
        <div id=""divOfDialogIMG""> <input type=""image"" id=""MyImage"" name=""myImage"" class=""img""></div>
        <div id=""MyUploader_wrapper""><input type=""file"" id=""MyUploader"" name=""myUploader"" class=""uploader""></div><br>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(977, 61, true);
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n<div id=\"dialog_Add\" title=\"Attention\">\r\n    ");
            EndContext();
            BeginContext(1038, 577, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae3d3cd2ae08427193e7d87e64e2e8dd", async() => {
                BeginContext(1044, 564, true);
                WriteLiteral(@"
        <p>If you want to add any item , please insert its features !</p><br>
        <p>Persian brand name : </p>
        <input type=""text"" id=""_PersianName4Add"" name=""PersianName4Add""><br>
        <p>English brand name : </p>
        <input type=""text"" id=""_EnglishName4Add"" name=""EnglishName4Add""><br>

        <div id=""divOfDialogIMG4Add""> <input type=""image"" id=""MyImage4Add"" name=""myImage4Add"" class=""img""></div>
        <div id=""MyUploader_wrapper4Add""><input type=""file"" id=""MyUploader4Add"" name=""myUploader4Add"" class=""uploader""></div><br>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1615, 1236, true);
            WriteLiteral(@"
</div>


<div id=""dialog_Delete"" title=""Attention"">

    <p>Are you sure to delete an item with this features?</p>
    <p>Persian brand name : </p> <p id=""pers4Del""></p>
    <p>English brand name : </p> <p id=""eng4Del""></p>
    <img id=""MyImage4Del"" class=""img"" />

</div>



<div id=""dialog_Details"" title=""Attention"">

    <p>Selected item details : </p>
    <p>Persian brand name : </p> <p id=""pers4Details""></p>
    <p>English brand name : </p> <p id=""eng4Details""></p>
    <img id=""MyImage4Details"" class=""img"" />

</div>



<div id=""dialog_PicError"" title=""Attention"">

    <p>The selected image is not in suitable format , please retry by another images</p><br>


</div>

<div class=""block"">
    <button type=""button"" value=""Add"" style=""height:50px;"" onclick=""AddItem()"" class=""btn btn-warning btn-xs btn-block"">Add </button>
</div>

<table id=""table"" class=""table"">
    <thead>
        <tr>
            <th>
                Persian brand name
            </th>
           ");
            WriteLiteral(" <th>\r\n                English brand name\r\n            </th>\r\n            <th>\r\n                Brand  picture\r\n            </th>\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody id=\"MyTbody\"></tbody>\r\n\r\n\r\n</table>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2874, 653, true);
                WriteLiteral(@"
    <script src=""/js/jquery.unobtrusive-ajax.min.js""></script>

    <script src=""/jquery-ui-1.12.1/external/jquery/jquery.js""></script>
    <script src=""/jquery-ui-1.12.1/jquery-ui.js""></script>

    <script>

        var MyResult;

        var _rowIndex;
        var _brandId;


        //var persianBrandName4DialogBox="""";
        //var englishBrandName4DialogBox="""";
        //var isShownPictureOfBrandInMainPage4DialogBox=false;


        $(document).ready(function () {


            FetchAllBrandsFromBrandsTBL();


        });




function FetchAllBrandsFromBrandsTBL() {



        $.ajax({
            url: '");
                EndContext();
                BeginContext(3528, 15, false);
#line 138 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
             Write(MyDomain.Domain);

#line default
#line hidden
                EndContext();
                BeginContext(3543, 312, true);
                WriteLiteral(@"' + '/api/BrandCRUD'/* + document.getElementById(""IdOfClickedItem"").value*/,
            async: false,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            //data: model,
            headers: {
            'Authorization': 'Bearer ");
                EndContext();
                BeginContext(3856, 16, false);
#line 145 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                                Write(Model.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(3872, 3036, true);
                WriteLiteral(@"'
            },
            /////////data: { Role: $(this).val() },
            success: function (result) {

                if (result.length != 0) {
                    MyResult = result;






                    for (i = 0; i < result.length; i++) {
                        var brandid = String(result[i][""BrandId""]);
                        var pers = String(result[i][""PersianBrandName""]);
                        var eng = String(result[i][""EnglishBrandName""]);




                        var append = ""<tr id='"" + result[i][""BrandId""] + ""' class='list_1_'>"" +
                            ""<td class='ColOfPersianName'>"" +
                            result[i][""PersianBrandName""] +
                            ""</td>"" +

                            ""<td class='ColOfEnglishName'>"" +
                            result[i][""EnglishBrandName""] +
                            ""</td>"" +

                            ""<td height=90px class='ImageColumn'>"" +
                            ""<i");
                WriteLiteral(@"mg id='test"" + brandid + ""' alt='test' src='' height='70px'/>"" +

                            ""</td>"" +


                            ""<td>"" +
                            '<table><tr><td>' +
                            '<button type=""button"" value=""Edit"" style=""height:50px;"" onclick=' +
                            '""EditThisItem(' + i + "",'"" + brandid + ""', "" + ""'"" + pers + ""'"" + ',' + ""'"" + eng + ""'"" + ')"" id =' +
                            '""AddButton"" class=""btn btn-warning btn-xs btn-block"" > ' + ""Edit"" + '</button > ' +
                            '</td><td>' +
                            '<button type=""button"" value=""Details"" style=""height:50px; ""  onclick=' +
                            '""ShowItemDetails(' + ""'"" + brandid + ""'"" + ')"" id = ""ShowDetails""  class=""btn btn-primary btn-xs btn-block"" > ' +
                            ""Details"" + '</button > ' +
                            '</td><td>' +
                            '<button type=""button"" value=""Delete"" style=""height:50px; "" oncl");
                WriteLiteral(@"ick=' +
                            '""DeleteItem(' + ""'"" + brandid + ""'"" + ')"" id = ""AddButton"" class=""btn btn-danger btn-xs btn-block"" > ' +
                            ""Delete"" + '</button > ' +
                            '</td></tr></table>'


                        ""</td>"" +
                            ""</tr>"";






                        $(""#MyTbody"").append(append);





                        var element = document.getElementById('test' + brandid);
                        element.empty;


                        LoadOnePic(result[i][""BrandId""]);






                    }


                }

            }
            ,
            error: function (error) { }
        });

    return MyResult;




       }





        function LoadOnePic(brandId) {

            //var request = function () {
                var ajaxOptions = {};
                ajaxOptions.cache = false;
                ajaxOptions.url = '");
                EndContext();
                BeginContext(6909, 15, false);
#line 248 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                              Write(MyDomain.Domain);

#line default
#line hidden
                EndContext();
                BeginContext(6924, 147, true);
                WriteLiteral("\' + \'/api/BrandCRUD/GetPic/\'+ brandId,\r\n                ajaxOptions.type = \"GET\";\r\n                ajaxOptions.headers = {\'Authorization\': \'Bearer ");
                EndContext();
                BeginContext(7072, 16, false);
#line 250 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                                                           Write(Model.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(7088, 763, true);
                WriteLiteral(@"'};
            ajaxOptions.headers.Accept = ""application/octet-stream""
            ajaxOptions.success = function (result) {



                if (result != undefined) {

                    $(""#test"" + brandId).attr(""src"", ""data:image/png;base64,"" + result);
                }
                    //alert(customerId);

                };
                ajaxOptions.error = function (jqXHR) {
                    console.log(""found error"");
                    console.log(jqXHR);
                };
                $.ajax(ajaxOptions);
        }





        function LoadOnePic4DialogBox(brandId) {

            
                var ajaxOptions = {};
                ajaxOptions.cache = false;
                ajaxOptions.url = '");
                EndContext();
                BeginContext(7852, 15, false);
#line 279 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                              Write(MyDomain.Domain);

#line default
#line hidden
                EndContext();
                BeginContext(7867, 147, true);
                WriteLiteral("\' + \'/api/BrandCRUD/GetPic/\'+ brandId,\r\n                ajaxOptions.type = \"GET\";\r\n                ajaxOptions.headers = {\'Authorization\': \'Bearer ");
                EndContext();
                BeginContext(8015, 16, false);
#line 281 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                                                           Write(Model.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(8031, 6283, true);
                WriteLiteral(@"'};
            ajaxOptions.headers.Accept = ""application/octet-stream""
            ajaxOptions.success = function (result) {



                if (result != undefined) {



                    $(""#MyImage"").attr(""src"", ""data:image/png;base64,"" + result);

                    $(""#MyImage4Del"").attr(""src"", ""data:image/png;base64,"" + result);

                    $(""#MyImage4Details"").attr(""src"", ""data:image/png;base64,"" + result);

                }
                else {
                    $(""#MyImage"").attr(""src"", ""data:image/png;base64,"" + null);

                    $(""#MyImage4Del"").attr(""src"", ""data:image/png;base64,"" + null);

                    $(""#MyImage4Details"").attr(""src"", ""data:image/png;base64,"" + null);
                }


                  };
                ajaxOptions.error = function (jqXHR) {
                    console.log(""found error"");
                    console.log(jqXHR);

                };
                $.ajax(ajaxOptions);
        }


    ");
                WriteLiteral(@"    function AddItem() {

            document.getElementById(""cssReference4MessageBox"").innerHTML =
                ' <link href=""/jquery-ui-1.12.1/jquery-ui.css"" rel=""stylesheet""/> ';

            $(document).ready(function () {

                $('#_PersianName4Add').val('');
                $('#_EnglishName4Add').val('');
                $(""#MyImage4Add"").attr(""src"", ""data:image/png;base64,"" + null);
                $('#MyUploader4Add').val('');

                $(""#dialog_Add"").dialog(""open"");

            });
        }



        function DeleteItem(brandid) {

            _brandId = brandid;

            document.getElementById(""cssReference4MessageBox"").innerHTML =
                ' <link href=""/jquery-ui-1.12.1/jquery-ui.css"" rel=""stylesheet""/> ';

            $(document).ready(function () {


                var PersText = document.body.querySelector(""[id='"" + brandid + ""'] .ColOfPersianName"");
                var EngText = document.body.querySelector(""[id='"" + brandid ");
                WriteLiteral(@"+ ""'] .ColOfEnglishName"");





                document.getElementById('pers4Del').innerHTML = PersText.textContent;
                document.getElementById('eng4Del').innerHTML = EngText.textContent;



                LoadOnePic4DialogBox(brandid);


                $(""#dialog_Delete"").dialog(""open"");

            });
        }




                function ShowItemDetails(brandid) {

                    _brandId = brandid;

                    document.getElementById(""cssReference4MessageBox"").innerHTML =
                        ' <link href=""/jquery-ui-1.12.1/jquery-ui.css"" rel=""stylesheet""/> ';

                    $(document).ready(function () {


                        var PersText = document.body.querySelector(""[id='"" + brandid + ""'] .ColOfPersianName"");
                        var EngText = document.body.querySelector(""[id='"" + brandid + ""'] .ColOfEnglishName"");





                        document.getElementById('pers4Details').innerHTML = PersText.textConten");
                WriteLiteral(@"t;
                        document.getElementById('eng4Details').innerHTML = EngText.textContent;



                        LoadOnePic4DialogBox(brandid);


                        $(""#dialog_Details"").dialog(""open"");

                    });
                }




        function EditThisItem(rowIndex , brandId, persianBrandName, englishBrandName) {
            document.getElementById(""cssReference4MessageBox"").innerHTML =
                ' <link href=""/jquery-ui-1.12.1/jquery-ui.css"" rel=""stylesheet""/> ';

            _rowIndex = rowIndex;
            _brandId = brandId;

            //خط بالا باعث میشود که ریفرنس سی اس اس ، درست همان وقتی که لازمش داریم (یعنی وقتی می  خواهیم
            //خطوط پایین را اجرا کنیم ، به کد اچ تی ام ال اضافه شود)


            _rowIndex = rowIndex;
            brandId4DialogBox = brandId;




            document.getElementById('_PersianName4Edit').value = persianBrandName;
            document.getElementById('_EnglishName4Edit').value = eng");
                WriteLiteral(@"lishBrandName;
           

            LoadOnePic4DialogBox(brandId);

            


            $(document).ready(function () {
                $(""#dialog_Edit"").dialog(""open"");
                $(""#no"").selected = ""selected"";
            });
        }

        //this block cause to after changing the picture , the picture is changed suddenly :
        function readURL(input) {

            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.img').attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

        $(""#MyUploader"").change(function () {
            readURL(this);
        });

        $(""#MyUploader4Add"").change(function () {
            readURL(this);
        });



        ///////////////////////////////////////////////////////////////



        $(""#dialog_Edit"").dialog({
       ");
                WriteLiteral(@"     autoOpen: false,

            width: 400,
            modal: true,
            buttons: {
                'OK': function () {

                    var PersianName4Edit = $('input[name=""PersianName4Edit""]').val();
                    var EnglishName4Edit = $('input[name=""EnglishName4Edit""]').val();
                    var myImage = $('input[name=""myImage""]').val();
                    var myUploader = $('input[name=""myUploader""]').val();



                    EditAnItem(PersianName4Edit, EnglishName4Edit);

                    $(this).dialog('close');
                },
                'Cansel': function () {
                    $(this).dialog('close');
                }
            }
        });

        function EditAnItem(PersianName4Edit, EnglishName4Edit) {


            var model = new FormData();

            model.append(""BrandId"", _brandId);

            model.append(""PersianBrandName"", PersianName4Edit);

            model.append(""EnglishBrandName"", EnglishName4");
                WriteLiteral("Edit);\r\n\r\n            model.append(\"BrandPicture\", $(\"#MyUploader\")[0].files[0]);\r\n\r\n\r\n\r\n\r\n\r\n\r\n            $.ajax({\r\n                url: \'");
                EndContext();
                BeginContext(14315, 15, false);
#line 506 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                 Write(MyDomain.Domain);

#line default
#line hidden
                EndContext();
                BeginContext(14330, 137, true);
                WriteLiteral("\' + \'/api/BrandCRUD/EditBrand/\',\r\n                type: \"PUT\",\r\n                headers: {\r\n                    \'Authorization\': \'Bearer ");
                EndContext();
                BeginContext(14468, 16, false);
#line 509 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                                        Write(Model.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(14484, 3789, true);
                WriteLiteral(@"'
                },
                dataType: ""json"",
                data: model,
                processData: false,
                contentType: false,
                complete: function (data) {


                    if (data.status == 404)
                    {
                        $(""#MyUploader"").val('');

                        $(""#dialog_PicError"").dialog(""open"");
                    }
                    else
                    {


                        var append = ""<tr id='"" + _brandId + ""_'>"" +                            
                            ""<td class='ColOfPersianName'>"" +
                            data.responseJSON.persianBrandName +
                            ""</td>"" +
                            ""<td class='ColOfEnglishName'>"" +
                            data.responseJSON.englishBrandName +
                            ""</td>"" +
                            ""<td height=90px class='ImageColumn'>"" +
                            ""<img id='test"" + _br");
                WriteLiteral(@"andId + ""' alt='test' src='' height='70px'/>"" +

                            ""</td>"" +


                            ""<td>"" +
                            '<table><tr><td>' +
                            '<button type=""button"" value=""Edit"" style=""height:50px;"" onclick=' +
                            '""EditThisItem(' + _rowIndex + ',' + _brandId + ',' + ""'"" + data.responseJSON.persianBrandName +
                            ""'"" + ',' + ""'"" + data.responseJSON.englishBrandName + ""'"" + ')"" id =' +
                            '""AddButton"" class=""btn btn-warning btn-xs btn-block"" > ' + ""Edit"" + '</button > ' +
                            '</td><td>' +
                            '<button type=""button"" value=""Details"" style=""height:50px; ""  onclick=' +
                            '""ShowItemDetails(' + ""'"" + _brandId + ""'"" + ')"" id = ""ShowDetails""  class=""btn btn-primary btn-xs btn-block"" > ' +
                            ""Details"" + '</button > ' +
                            '</td><td>' +
            ");
                WriteLiteral(@"                '<button type=""button"" value=""Delete"" style=""height:50px; "" onclick=""DeleteItem(' + _brandId + ')"" id=' +
                            '""AddButton"" class=""btn btn-danger btn-xs btn-block"" > ' + ""Delete"" + '</button > ' +
                            '</td></tr></table>'


                        ""</td>"" +

                            ""</tr>"";


                        //Very important: What we did below is first to append an underline at the end of
                        //the ""append"" id(at above).Then, I moved that before of old row(on below).After that,
                        //I removed the old row.Then I chenged the append Id and removed underline from
                        //end of that.
                        //This was because we coud not have two eleman with similar Id at one time.
                        $(""#"" + _brandId).before(append);
                        $(""#"" + _brandId).remove();
                        document.getElementById(_brandId + '_').id = _brandI");
                WriteLiteral(@"d;
                        var element = document.getElementById('test' + _brandId);                      
                        LoadOnePic(_brandId);

                        $(""#MyUploader"").val('');
                    }


                }

            });
        }




        function AddAnItem(PersianName4Add, EnglishName4Add) {


            var model = new FormData();

            //model.append(""BrandId"", _brandId);

            model.append(""PersianBrandName"", PersianName4Add);

            model.append(""EnglishBrandName"", EnglishName4Add);

            model.append(""BrandPicture"", $(""#MyUploader4Add"")[0].files[0]);




            $.ajax({
                url: '");
                EndContext();
                BeginContext(18274, 15, false);
#line 602 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                 Write(MyDomain.Domain);

#line default
#line hidden
                EndContext();
                BeginContext(18289, 170, true);
                WriteLiteral("\' + \'/api/BrandCRUD/AddBrand\',\r\n                type: \"Post\",\r\n                ///async: false,\r\n                headers: {\r\n                    \'Authorization\': \'Bearer ");
                EndContext();
                BeginContext(18460, 16, false);
#line 606 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                                        Write(Model.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(18476, 3541, true);
                WriteLiteral(@"'
                },
                dataType: ""json"",
                data: model,
                processData: false,
                contentType: false,
                success: function (data) {




                        // $.each(data,
                        // function (i, item) {
                        _brandId = data.BrandId;

                        var append = ""<tr id='"" + data.BrandId + ""'>"" +
                            ""<td class='ColOfPersianName'>"" +
                            data.PersianBrandName +
                            ""</td>"" +
                            ""<td class='ColOfEnglishName'>"" +
                            data.EnglishBrandName +
                            ""</td>"" +

                            ""<td height=90px class='ImageColumn'>"" +
                            ""<img id='test"" + _brandId + ""' alt='test' src='' height='70px'/>"" +

                            ""</td>"" +


                            ""<td>"" +
                            '<ta");
                WriteLiteral(@"ble><tr><td>' +
                            '<button type=""button"" value=""Edit"" style=""height:50px;"" onclick=' +
                            '""EditThisItem(' + _rowIndex + ',' + _brandId + ',' + ""'"" + data.PersianBrandName + ""'"" +
                            ',' + ""'"" + data.EnglishBrandName + ""'"" + ',' + ')"" id =' +
                            '""AddButton"" class=""btn btn-warning btn-xs btn-block"" > ' + ""Edit"" + '</button > ' +
                            '</td><td>' +
                            '<button type=""button"" value=""Details"" style=""height:50px; ""  onclick=' +
                            '""ShowItemDetails(' + ""'"" + _brandId + ""'"" + ')"" id = ""ShowDetails""  class=""btn btn-primary btn-xs btn-block"" > ' +
                            ""Details"" + '</button > ' +
                            '</td><td>' +
                            '<button type=""button"" value=""Delete"" style=""height:50px; "" onclick=""DeleteItem(' + _brandId + ')"" id=""AddButton"" ' +
                            'class=""btn btn-dange");
                WriteLiteral(@"r btn-xs btn-block"" > ' + ""Delete"" + '</button > ' +
                            '</td></tr></table>'


                        ""</td>"" +

                            ""</tr>"";


                              //Very important: What we did below is first to append an underline at the end of
                        //the ""append"" id(at above).Then, I moved that before of old row(on below).After that,
                        //I removed the old row.Then I chenged the append Id and removed underline from
                        //end of that.
                        //This was because we coud not have two eleman with similar Id at one time.
                        $('#MyTbody').append(append);



                        var element = document.getElementById('test' + _brandId);
                       

                        LoadOnePic(_brandId);

                        $(""#MyUploader4Add"").val('');
                    
                },
                error: function (error) {
      ");
                WriteLiteral(@"              if (error.status == 404) {
                        $(""#MyUploader4Add"").val('');
                        $(""#dialog_PicError"").dialog(""open"");
                    }


                }

            });
        }




                function DelAnItem(brandid) {


            var model = new FormData();            
                    model.append(""brandId"", brandid);
                    
            $.ajax({
                url: '");
                EndContext();
                BeginContext(22018, 15, false);
#line 695 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                 Write(MyDomain.Domain);

#line default
#line hidden
                EndContext();
                BeginContext(22033, 142, true);
                WriteLiteral("\' + \'/api/BrandCRUD/DeleteBrand/\',\r\n                type: \"Delete\",\r\n                headers: {\r\n                    \'Authorization\': \'Bearer ");
                EndContext();
                BeginContext(22176, 16, false);
#line 698 "E:\Iman madaeni\MyGitProj4CV\Brands\Brands\Brands.Web\Views\BrandCRUDclient\BrandCRUD.cshtml"
                                        Write(Model.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(22192, 2960, true);
                WriteLiteral(@"'
                },
                dataType: ""json"",
                data: model,
                processData: false,
                contentType: false,
                complete: function (data) {

                    if (data == true) {
                        //یعنی آیتم با موفقیت حذف شده
                    }

                           //Very important: What we did below is first to append an underline at the end of
                        //the ""append"" id(at above).Then, I moved that before of old row(on below).After that,
                        //I removed the old row.Then I chenged the append Id and removed underline from
                        //end of that.
                        //This was because we coud not have two eleman with similar Id at one time.
                    $('#MyTbody #' + brandid).remove();

                }

            });
        }
        

        $(""#dialog_Add"").dialog({
            autoOpen: false,

            width: 400,
            mo");
                WriteLiteral(@"dal: true,
            buttons: {
                'OK': function () {

                    var PersianName4Add = $('input[name=""PersianName4Add""]').val();
                    var EnglishName4Add = $('input[name=""EnglishName4Add""]').val();
                    var myImage = $('input[name=""myImage4Add""]').val();
                    var myUploader = $('input[name=""myUploader4Add""]').val();



                    AddAnItem(PersianName4Add, EnglishName4Add);

                    $(this).dialog('close');
                },
                'Cansel': function () {
                    $(this).dialog('close');
                }
            }
                });



                $(""#dialog_Delete"").dialog({
                    autoOpen: false,

                    width: 400,
                    modal: true,
                    buttons: {
                        'OK': function () {

               
                            DelAnItem(_brandId);

                            $(this).di");
                WriteLiteral(@"alog('close');
                        },
                        'Cansel': function () {
                            $(this).dialog('close');
                        }
                    }
                });



                $(""#dialog_Details"").dialog({
                    autoOpen: false,

                    width: 400,
                    modal: true,
                    buttons: {
                        'OK': function () {                    
                            $(this).dialog('close');
                        }
                    }
        });

        $(""#dialog_PicError"").dialog({
            autoOpen: false,

            width: 400,
            modal: true,
            buttons: {
                'OK': function () {                    
                    $(this).dialog('close');
                }

            }
        });

    </script>

");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
