#pragma checksum "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a70c99c33be124531b4e70f7b836a851bc24f46e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MusicPlayer_Index), @"mvc.1.0.view", @"/Views/MusicPlayer/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a70c99c33be124531b4e70f7b836a851bc24f46e", @"/Views/MusicPlayer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_MusicPlayer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 30%; display: inline-block; background-color: rgba(255, 255, 255, 0.5);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MusicPlayer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlaylistManagement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 1 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
  
    ViewData["Title"] = "Music Player";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script src=""https://unpkg.com/wavesurfer.js""></script>

<div id=""waveform""></div>

<div class=""controls"" style=""text-align:center;"">
    <button onclick=""skipBackward()"">Backward</button>

    <button onclick=""playPause()"">Play/Pause</button>

    <button onclick=""skipForward()"">Forward</button>

    <button onclick=""toggleMute()"">Toggle Mute</button>
</div>
<br />

<!-- Affiche toutes les playlists en music associées d'un utilisteur -->
<!-- TODO: clique sur le nom d'une playlist pour afficher les musiques qu'elle contient -->
");
#nullable restore
#line 22 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
  
    // var userPlaylist = ((List<Playlist>)ViewData["playlists"]).First();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"text-align: center\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a70c99c33be124531b4e70f7b836a851bc24f46e5990", async() => {
                WriteLiteral("\r\n        <!-- Ajoute une ligne dans la table playlist -->\r\n        <label style=\"font-size:36px;\">Create playlist</label>\r\n        <button name=\"action\" type=\"submit\" value=\"AP{0}\">");
                WriteLiteral("\r\n            <img src=\"/images/icons/add.png\" style=\"vertical-align:middle;\" width=\"30\" name=\"file\" value=\"filename\" />\r\n        </button>\r\n        <br />\r\n");
#nullable restore
#line 34 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
         foreach (var playlist in ViewData["playlists"] as IList<Playlist>)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <label style=\"font-size:36px;\">");
#nullable restore
#line 36 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
                                      Write(playlist.PlaylistTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n            <input for=\"action\" type=\"hidden\" name=\"title\"");
                BeginWriteAttribute("value", " value=\"", 1510, "\"", 1518, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
                WriteLiteral("            <!-- Update la colonne PlaylistTitle dans la table playlist -->\r\n            <button name=\"action\" type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 1650, "\"", 1674, 3);
                WriteAttributeValue("", 1658, "UP{", 1658, 3, true);
#nullable restore
#line 40 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
WriteAttributeValue("", 1661, playlist.Id, 1661, 12, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1673, "}", 1673, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                <img src=\"/images/icons/edit.png\" style=\"vertical-align: middle;\" width=\"20\" />\r\n            </button>\r\n            <!-- Supprime une ligne dans la table playlist -->\r\n            <button name=\"action\" type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 1909, "\"", 1933, 3);
                WriteAttributeValue("", 1917, "DP{", 1917, 3, true);
#nullable restore
#line 44 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
WriteAttributeValue("", 1920, playlist.Id, 1920, 12, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1932, "}", 1932, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                <img src=\"/images/icons/delete.png\" style=\"vertical-align: middle;\" width=\"20\" />\r\n            </button>\r\n");
                WriteLiteral("            <br />\r\n");
#nullable restore
#line 49 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
             foreach (var music in ViewData["musics"] as IList<Music>)
            {
                if (playlist.Id == music.IdPlaylist)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <label for=\"action\" style=\"font-size:24px;\" name=\"title\" value=\"title\" ondblclick=\"this.readOnly=\'\';\">");
#nullable restore
#line 53 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
                                                                                                                     Write(music.MusicTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                    <input for=\"action\" type=\"hidden\" name=\"title\"");
                BeginWriteAttribute("value", " value=\"", 2456, "\"", 2464, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <!-- Update la colonne MusicTitle dans la table music -->\r\n");
                WriteLiteral("                    <button name=\"action\" type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 2606, "\"", 2627, 3);
                WriteAttributeValue("", 2614, "UM{", 2614, 3, true);
#nullable restore
#line 57 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
WriteAttributeValue("", 2617, music.Id, 2617, 9, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2626, "}", 2626, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <img src=\"/images/icons/edit.png\" style=\"vertical-align:top;\" width=\"15\" />\r\n                    </button>\r\n");
                WriteLiteral("                    <!-- Supprime une ligne dans la table music -->\r\n                    <button name=\"action\" type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 2889, "\"", 2910, 3);
                WriteAttributeValue("", 2897, "DM{", 2897, 3, true);
#nullable restore
#line 62 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
WriteAttributeValue("", 2900, music.Id, 2900, 9, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2909, "}", 2909, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <img src=\"/images/icons/delete.png\" style=\"vertical-align:top;\" width=\"15\" />\r\n                    </button>\r\n                    <br />\r\n");
#nullable restore
#line 66 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <!-- Ajoute une ligne dans la table music -->\r\n            <input for=\"action\" type=\"file\" name=\"file\"");
                BeginWriteAttribute("value", " value=\"", 3224, "\"", 3232, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <button name=\"action\" type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 3285, "\"", 3309, 3);
                WriteAttributeValue("", 3293, "AM{", 3293, 3, true);
#nullable restore
#line 70 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
WriteAttributeValue("", 3296, playlist.Id, 3296, 12, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3308, "}", 3308, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                <img src=\"/images/icons/add.png\" style=\"vertical-align: middle;\" width=\"20\" />\r\n            </button>\r\n            <br />\r\n");
#nullable restore
#line 74 "C:\Users\AlexZ\OneDrive\Bureau\WebApp\WebApp\Views\MusicPlayer\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n<script>\r\n");
            WriteLiteral("\r\n    // console.log(list);\r\n");
            WriteLiteral(@"
    // var userFolder = ('/media/' + id + '/');
    var userFolder = ('/media/' + 'audio.mp3');
    // console.log(userFolder + list[0] + '/audio.mp3');
    
    // create : Create an instance, passing the container selector and options:
    var wavesurfer = WaveSurfer.create({
    container: '#waveform',
    waveColor: 'violet',
    progressColor: 'purple'
    });

    // load : Loads audio from URL via XHR
    wavesurfer.load(userFolder);

    // on : Subscribe to some events
    wavesurfer.on('ready', function () { // ready : When audio is loaded, decoded and the waveform drawn.
        // load : Loads audio from URL via XHR
        wavesurfer.load(userFolder);
        wavesurfer.play();
    })

    // Rewind skipLength seconds.
    function skipBackward() {
    wavesurfer.skipBackward();
    }

    // Plays if paused, pauses if playing.
    function playPause() {
    wavesurfer.playPause();
    }

    // Skip ahead skipLength seconds.
    function skipForward() {
    wav");
            WriteLiteral(@"esurfer.skipForward();
    }
    // Toggles the volume on and off.
    function toggleMute() {
    wavesurfer.toggleMute();
    }
</script>


<script>
    document.querySelectorAll(""label"").forEach(function (node) {
        node.ondblclick = function () { // double click pour edit (mettre un input à la place d'un label)
            var oldValue = this.innerHTML;
            var input = document.createElement(""input""); // input de changement de text du label

            input.value = oldValue;
            input.onblur = function () { // après être sorti du mode edit
                var hiddenInput = document.querySelector('input[type=""hidden""]');

                if (this.value != """") {
                    var newValue = this.value;
                    this.parentNode.innerHTML = newValue;
                    hiddenInput.value = newValue;
                } else {
                    this.parentNode.innerHTML = oldValue;
                    hiddenInput.value = oldValue;
              ");
            WriteLiteral(@"  }
                // hiddenInput.createElement(""name"").value = ""test""; // creation element name

            } // fin blur
            this.innerHTML = """";
            this.appendChild(input);
            input.focus();
        } // fin dblclick
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
