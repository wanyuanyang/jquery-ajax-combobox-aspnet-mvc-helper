(function(b){b.ajaxComboBox=function(f,c,a,d){function $(a,b){ndx=-1;for(i=a.length-1;i>0;--i)if(a.charAt(i)=="."){ndx=i;break}return a.substring(0,ndx+1)+b+a.substring(ndx+1,a.length)}function F(){var c="#"+b(f).attr("id")+" ."+a.p_area_cls;b(c).length==1?b(c+" ."+a.p_del_cls).css("visibility","hidden"):b(c+" ."+a.p_del_cls).css("visibility","visible")}function G(c){y++;var L=b("<div></div>").addClass(a.p_area_cls),l=b("<div></div>"),s=b("<div></div>").addClass(a.p_del_cls);b("<img />").attr({alt:d.del_btn,
title:d.del_title,src:a.p_del_img1}).mouseover(function(c){b(c.target).attr("src",a.p_del_img2)}).mouseout(function(c){b(c.target).attr("src",a.p_del_img1)}).click(function(a){var c=a.target,a=b(f).find("input[type=text]").eq(0).attr("id");b(c).parent().parent().remove();c=b(f).find("input[type=text]").eq(0).attr("id");b("label[for="+a+"]").attr("for",c);F()}).appendTo(s);var H=b('<div style="clear:both"></div>');a.packagex?(l.addClass(a.p_acbox_cls),L.append(l).append(s).append(H),b(f).append(L).append(z),
l.width(I),b(f).width(I+s.width()),z.css("margin-left",l.width())):(L.append(l),b(f).append(L),l.width(b(f).width()));c.box=new T(l);F()}function T(c){function f(a){return a.replace(/^.|_./g,function(a){return a.replace(/_(.)/,"$1").toUpperCase()})}function l(b){var c=A(),b=c&&!b?c.offset().top:t.offset().top,d;a.sub_info?(d=q.children("table:visible"),d=d.height()+parseInt(d.css("border-top-width"),10)+parseInt(d.css("border-bottom-width"),10)):(ba(),d=M);var g=document.documentElement.clientHeight,
e=document.documentElement.scrollTop>0?document.documentElement.scrollTop:document.body.scrollTop,h=e+g-d,f;if(c.length)if(b<e||d>g)f=b-e;else if(b>h)f=b-h;else return;else b<e&&(f=b-e);window.scrollBy(0,f)}function s(){if(a.select_only)if(g.val()!=""){r.val()!=""?(e.attr("title",d.select_ok),e.children("img").attr({src:a.select_ok_img,alt:d.get_all_alt,title:d.select_ok})):(e.attr("title",d.select_ng),e.children("img").attr({src:a.select_ng_img,alt:d.get_all_alt,title:d.select_ng}));return}else r.val("");
e.attr("title",d.get_all_btn);e.children("img").attr({src:a.button_img,alt:d.get_all_alt,title:d.get_all_btn})}function H(){U=setTimeout(function(){now_value=g.val();now_value!=J&&(a.select_only&&(r.val(""),s()),o=1,j=!0,n());J=now_value;H()},500)}function G(){B=setTimeout(function(){N==!1&&v==!1&&w()},500)}function z(b){if(/27$|38$|40$|^9$/.test(b.keyCode)&&x.is(":visible")||/^37$|39$|13$|^9$/.test(b.keyCode)&&A()||/40$/.test(b.keyCode))switch(b.preventDefault&&b.preventDefault(),b.stopPropagation&&
b.stopPropagation(),b.cancelBubble=!0,b.returnValue=!1,b.keyCode){case 37:b.shiftKey?ca():da();break;case 38:C=!0;(b=A())?(D(b.prev()),b.removeClass(a.select_class).prev().addClass(a.select_class)):(D(h.children("li:last-child"),h.children("li").length-1),h.children("li:last-child").addClass(a.select_class));l();break;case 39:b.shiftKey?ea():fa();break;case 40:!x.is(":visible")&&!A()?(j=!1,n()):(C=!0,(b=A())?(D(b.next()),b.removeClass(a.select_class).next().addClass(a.select_class)):(D(h.children("li:first-child"),
0),h.children("li:first-child").addClass(a.select_class)),l());break;case 9:O=!0;w();break;case 13:V();break;case 27:O=!0,w()}else H(),r.valid()}function F(){e.children("img").attr("src",a.button_img);P=!1;W?e.mouseover():e.mouseout()}function I(){Q&&(Q.abort(),Q=!1,F())}function n(){var c=j?b.trim(g.val()):"",aa=j?o:p;j&&c.length<a.minchars?w():(I(),q.children("table").css("display","none"),P=!0,e.attr("title",d.loading),e.children("img").attr({src:a.load_img,alt:d.loading_alt,title:d.loading}),
b.globalEval("var xxx = "+a.cascaded_word+";"),Q=b.post(a.source,{cascaded_word:xxx,q_word:c,page_num:aa,per_page:a.per_page,field:a.field,show_field:a.show_field,hide_field:a.hide_field,select_field:K,order_field:a.order_field,order_by:a.order_by,primary_key:ga,db_table:a.db_table},function(d){if(d.candidate){d.cnt>d.cnt_page?T(d.cnt,d.cnt_page,aa):k.css("display","none");var g=[];b.each(d.candidate,function(b,d){g[b]=d.replace(RegExp(c,"ig"),function(b){return'<span class="'+a.match_class+'">'+
b+"</span>"})});var e=[];d.attached?b.each(d.attached,function(a,b){e[a]=b}):e=!1;var f=[];d.primary_key?b.each(d.primary_key,function(a,b){f[a]=b}):f=!1;ha(g,e,f)}else w();F();h.children("li:first-child").addClass(a.select_class);D(h.children("li:first-child"));l(!0)}))}function T(c,e,h){var f=a.per_page*(h-1)+1,e=d.page_info.replace("cnt",c).replace("num_page_top",f).replace("num_page_end",f+e-1);k.text(e);e=b("<p></p>");c=Math.ceil(c/a.per_page);j?R=c:S=c;for(var m=h-Math.ceil((a.navi_num-1)/2),
f=h+Math.floor((a.navi_num-1)/2);m<1;)m++,f++;for(;f>c;)f--;for(;f-m<a.navi_num-1&&m>1;)m--;h==1?(a.navi_simple||b("<span></span>").text("<< 1").addClass("page_end").appendTo(e),b("<span></span>").text(d.prev).addClass("page_end").appendTo(e)):(a.navi_simple||b("<a></a>").attr({href:"javascript:void(0)","class":"navi_first"}).text("<< 1").attr("title",d.first_title).appendTo(e),b("<a></a>").attr({href:"javascript:void(0)","class":"navi_prev"}).text(d.prev).attr("title",d.prev_title).appendTo(e));
for(i=m;i<=f;i++)m=i==h?'<span class="current">'+i+"</span>":i,b("<a></a>").attr({href:"javascript:void(0)","class":"navi_page"}).html(m).appendTo(e);h==c?(b("<span></span>").text(d.next).addClass("page_end").appendTo(e),a.navi_simple||b("<span></span>").text(c+" >>").addClass("page_end").appendTo(e)):(b("<a></a>").attr({href:"javascript:void(0)","class":"navi_next"}).text(d.next).attr("title",d.next_title).appendTo(e),a.navi_simple||b("<a></a>").attr({href:"javascript:void(0)","class":"navi_last"}).text(c+
" >>").attr("title",d.last_title).appendTo(e));c>1&&(k.append(e).show(),b(".navi_first").mouseup(function(a){g.focus();a.preventDefault();ca()}),b(".navi_prev").mouseup(function(a){g.focus();a.preventDefault();da()}),b(".navi_page").mouseup(function(a){g.focus();a.preventDefault();j?o=parseInt(b(this).text(),10):p=parseInt(b(this).text(),10);n()}),b(".navi_next").mouseup(function(a){g.focus();a.preventDefault();fa()}),b(".navi_last").mouseup(function(a){g.focus();a.preventDefault();ea()}))}function ca(){j?
o>1&&(o=1,n()):p>1&&(p=1,n())}function da(){j?o>1&&(o--,n()):p>1&&(p--,n())}function fa(){j?o<R&&(o++,n()):p<S&&(p++,n())}function ea(){j?o<R&&(o=R,n()):p<S&&(p=S,n())}function ha(c,f,l){if(c.length==0)w();else{h.empty();q.empty();for(var u=0;u<c.length;u++){var m=b("<li>"+c[u]+"</li>");a.select_only&&m.attr("id",l[u]);h.append(m);if(f){for(var m=b("<table><tbody></tbody></table>"),j=0;j<f[u].length;j++){var n=a.sub_as[f[u][j][0]]!=null?a.sub_as[f[u][j][0]]:f[u][j][0],k=b("<tr></tr>");k.append("<th>"+
n+"</th>");k.append("<td>"+f[u][j][1]+"</td>");m.children("tbody").append(k)}q.append(m)}}f&&q.insertAfter(h);x.show().width(t.width()+parseInt(t.css("border-left-width"))+parseInt(t.css("border-right-width")));h.children("li").mouseover(function(){C?C=!1:(D(this),h.children("li").removeClass(a.select_class),b(this).addClass(a.select_class))}).mousedown(function(){v=!0;clearTimeout(B)}).mouseup(function(a){v=!1;C?C=!1:(a.preventDefault(),a.stopPropagation(),V(),g.focus())});e.attr("title",d.close_btn);
e.children("img").attr({src:a.load_img,alt:d.close_alt,title:d.close_btn})}}function A(){if(!x.is(":visible"))return!1;var b=h.children("li."+a.select_class);b.length||(b=!1);return b}function V(){l(!0);var c=A();c&&(g.val(c.text()),w(),J=g.val(),a.select_only&&(r.val(c.attr("id")),s()),a.on_selected!=void 0&&b.globalEval(a.on_selected));g.change();r.valid()}function w(){O&&(l(!0),O=!1);x.hide();q.children("table").css("display","none");I();s()}function ba(){M==null&&($obj=h.children("li:first"),
M=$obj.height()+parseInt($obj.css("border-top-width"),10)+parseInt($obj.css("border-bottom-width"),10)+parseInt($obj.css("padding-top"),10)+parseInt($obj.css("padding-bottom"),10))}function D(c,d){if(a.sub_info&&(X==null&&(X=parseInt(h.css("border-top-width"),10)),Y==null&&(Y=k.height()+parseInt(k.css("border-top-width"),10)+parseInt(k.css("border-bottom-width"),10)+parseInt(k.css("padding-top"),10)+parseInt(k.css("padding-bottom"),10)),ba(),Z==null&&(Z=h.width()+parseInt(h.css("padding-left"),10)+
parseInt(h.css("padding-right"),10)+parseInt(h.css("border-left-width"),10)+parseInt(h.css("border-right-width"),10)),d==null&&(d=h.children("li").index(c)),q.children("table").css("display","none"),d>-1)){var e=0;k.css("display")!="none"&&(e+=Y);e+=X+M*d;var f=Z;b.browser.mozilla&&(e++,f++);e+="px";f+="px";q.children("table:eq("+d+")").css({position:"absolute",top:e,left:f,display:b.browser.msie?"block":"table"})}}this.hidden=this.input=null;this.resetPage=function(){p=1};b.ajaxSetup({cache:!1});
var N=!1,B=!1,U=!1,j=!1,p=1,o=1,S=1,R=1,P=!1,W=!1,v=!1,Q=!1,O=!1,C=!1,J="",Y=null,X=null,M=null,Z=null,K;a.sub_info?K=a.show_field&&!a.hide_field?a.field+","+a.show_field:"*":(K=a.field,a.hide_field="");a.select_only&&K!="*"&&(K+=","+a.primary_key);var ga=a.select_only?a.primary_key:"";b(c).addClass(a.combo_class);var t=b('<table cellspacing="1"><tbody><tr><th></th><td></td></tr></tbody></table>').addClass(a.table_class),g=b("<input />").attr({type:"text",autocomplete:"off"}).addClass(a.input_class);
this.input=g;if(a.cake_rule){var E=f(a.cake_field);a.packagex?g.attr({name:"data["+a.cake_model+"]["+a.cake_field+"]["+(y-1)+"]",id:a.cake_model+E+(y-1)}):g.attr({name:"data["+a.cake_model+"]["+a.cake_field+"]",id:a.cake_model+E})}else g.attr({name:$(a.the_field_name,"txt_"),id:$(a.the_field_id,"txt_")});var E=t.children("tbody").children("tr").children("th"),e=t.children("tbody").children("tr").children("td");e.append("<img />");var x=b("<div></div>").addClass(a.re_area_class),k=b("<div></div>").addClass(a.navi_class),
h=b("<ul></ul>").addClass(a.results_class),q=b("<div></div>").addClass(a.sub_info_class),r=b('<input type="hidden" />').attr({name:a.the_field_name,id:a.the_field_id}).val("");this.hidden=r;r.attr(a.other_attr);s();E.append(g);x.append(k).append(h);b(c).append(t).append(x);a.select_only&&b(c).append(r);g.width(b(c).width()-e.children("img").width()-parseInt(E.css("padding-left"))-parseInt(E.css("padding-right"))-parseInt(e.css("padding-left"))-parseInt(e.css("padding-right"))-parseInt(e.css("border-left-width"))-
parseInt(e.css("border-right-width"))-parseInt(t.css("border-left-width"))-parseInt(t.css("border-right-width"))-3);(function(){a.init_val!==!1&&(a.select_only?(r.val(a.init_val[y-1]),b.post(a.init_src,{q_word:a.init_val[y-1],field:a.field,primary_key:a.primary_key,db_table:a.db_table},function(b){g.val(b);J=b;e.attr("title",d.select_ok);e.children("img").attr({src:a.select_ok_img,alt:d.get_all_alt,title:d.select_ok})})):(J=a.init_val[y-1],g.val(a.init_val[y-1])))})();e.mouseup(function(a){x.css("display")==
"none"?(clearInterval(U),j=!1,n(),g.focus()):w();a.stopPropagation()});e.mouseover(function(){W=!0;P||e.css("background-image","url("+a.ac_btn_on_img+")").addClass(a.btn_on_class).removeClass(a.btn_out_class)});e.mouseout(function(){W=!1;P||e.css("background-image","url("+a.ac_btn_out_img+")").addClass(a.btn_out_class).removeClass(a.btn_on_class)});e.mouseout();b.support.checkOn&&b.support.cssFloat?g.keypress(z):g.keydown(z);g.focus(function(){N=!0;H()});g.blur(function(){h.children("li").length==
1&&h.children("li:first").text()==b.trim(g.val())&&V();clearTimeout(U);N=!1;G();s()});g.mousedown(function(a){v=!0;clearTimeout(B);a.stopPropagation()});g.mouseup(function(a){g.focus();v=!1;a.stopPropagation()});k.mousedown(function(a){v=!0;clearTimeout(B);a.stopPropagation()});k.mouseup(function(a){g.focus();v=!1;a.stopPropagation()});q.mousedown(function(a){v=!0;clearTimeout(B);a.stopPropagation()});q.mouseup(function(a){g.focus();v=!1;a.stopPropagation()});b("body").mouseup(function(){clearTimeout(B);
N=!1;w()})}this.box=null;this.clearValue=function(){this.box.input.val("");this.box.hidden.val("");this.box.resetPage()};var y=0,I=b(f).width(),z=b("<div></div>").addClass(a.p_add_cls);a.packagex&&b("<img />").attr({alt:d.add_btn,title:d.add_title,src:a.p_add_img1}).mouseover(function(c){b(c.target).attr("src",a.p_add_img2)}).mouseout(function(c){b(c.target).attr("src",a.p_add_img1)}).click(function(){G(this,f)}).appendTo(z);if(a.init_val===!1)G(this,f);else{for(i=0;a.init_val.length>i;i++)G(this,
f);a.init_val=!1}};b.fn.ajaxComboBox=function(f,c){if(f){c=b.extend({source:f,db_table:"tbl",img_dir:"/Scripts/acbox/img/",field:"name",minchars:1,per_page:10,navi_num:5,navi_simple:!1,init_val:!1,init_src:"/TheJson/InitVal/",the_field_name:b(this).attr("id"),the_field_id:b(this).attr("id").replace(/\./g,"_"),mini:!1,lang:"ja",sub_info:!1,sub_as:{},show_field:"",hide_field:"",select_only:!1,primary_key:"id"},c);c=b.extend({order_field:c.field,order_by:"ASC",packagex:!1,p_del_img1:c.img_dir+"del_out.png",
p_del_img2:c.img_dir+"del_over.png",p_add_img1:c.img_dir+"add_out.png",p_add_img2:c.img_dir+"add_over.png",cake_rule:!1,cake_model:c.db_table,cake_field:c.field,p_area_cls:"box_area"+(c.mini?"_mini":""),p_acbox_cls:"combo_box"+(c.mini?"_mini":""),p_add_cls:"add_area"+(c.mini?"_mini":""),p_del_cls:"del_area"+(c.mini?"_mini":""),combo_class:"ac_combobox_area"+(c.mini?"_mini":""),table_class:"ac_table"+(c.mini?"_mini":""),input_class:"ac_input"+(c.mini?"_mini":""),button_class:"ac_button"+(c.mini?"_mini":
""),btn_on_class:"ac_btn_on"+(c.mini?"_mini":""),btn_out_class:"ac_btn_out"+(c.mini?"_mini":""),re_area_class:"ac_result_area"+(c.mini?"_mini":""),navi_class:"ac_navi"+(c.mini?"_mini":""),results_class:"ac_results"+(c.mini?"_mini":""),select_class:"ac_over"+(c.mini?"_mini":""),match_class:"ac_match"+(c.mini?"_mini":""),sub_info_class:"ac_attached"+(c.mini?"_mini":""),button_img:c.img_dir+"combobox_button"+(c.mini?"_mini":"")+".png",load_img:c.img_dir+"ajax-loader"+(c.mini?"_mini":"")+".gif",select_ok_img:c.img_dir+
"select_ok"+(c.mini?"_mini":"")+".png",select_ng_img:c.img_dir+"select_ng"+(c.mini?"_mini":"")+".png",ac_btn_on_img:c.img_dir+"btn_on"+(c.mini?"_mini":"")+".png",ac_btn_out_img:c.img_dir+"btn_out"+(c.mini?"_mini":"")+".png"},c);switch(c.lang){case "ja":var a={add_btn:"\u8ffd\u52a0\u30dc\u30bf\u30f3",add_title:"\u5165\u529b\u30dc\u30c3\u30af\u30b9\u3092\u8ffd\u52a0\u3057\u307e\u3059",del_btn:"\u524a\u9664\u30dc\u30bf\u30f3",del_title:"\u5165\u529b\u30dc\u30c3\u30af\u30b9\u3092\u524a\u9664\u3057\u307e\u3059",
next:"\u6b21\u3078",next_title:"\u6b21\u306e"+c.per_page+"\u4ef6 (\u53f3\u30ad\u30fc)",prev:"\u524d\u3078",prev_title:"\u524d\u306e"+c.per_page+"\u4ef6 (\u5de6\u30ad\u30fc)",first_title:"\u6700\u521d\u306e\u30da\u30fc\u30b8\u3078 (Shift + \u5de6\u30ad\u30fc)",last_title:"\u6700\u5f8c\u306e\u30da\u30fc\u30b8\u3078 (Shift + \u53f3\u30ad\u30fc)",get_all_btn:"\u5168\u4ef6\u53d6\u5f97 (\u4e0b\u30ad\u30fc)",get_all_alt:"\u753b\u50cf:\u30dc\u30bf\u30f3",close_btn:"\u9589\u3058\u308b (Tab\u30ad\u30fc)",close_alt:"\u753b\u50cf:\u30dc\u30bf\u30f3",
loading:"\u30ed\u30fc\u30c9\u4e2d...",loading_alt:"\u753b\u50cf:\u30ed\u30fc\u30c9\u4e2d...",page_info:"num_page_top - num_page_end \u4ef6 (\u5168 cnt \u4ef6)",select_ng:"\u6ce8\u610f : \u30ea\u30b9\u30c8\u306e\u4e2d\u304b\u3089\u9078\u629e\u3057\u3066\u304f\u3060\u3055\u3044",select_ok:"OK : \u6b63\u3057\u304f\u9078\u629e\u3055\u308c\u307e\u3057\u305f\u3002"};break;case "en":a={add_btn:"Add button",add_title:"add a box",del_btn:"Del button",del_title:"delete a box",next:"Next",next_title:"Next"+
c.per_page+" (Right key)",prev:"Prev",prev_title:"Prev"+c.per_page+" (Left key)",first_title:"First (Shift + Left key)",last_title:"Last (Shift + Right key)",get_all_btn:"Get All (Down key)",get_all_alt:"(button)",close_btn:"Close (Tab key)",close_alt:"(button)",loading:"loading...",loading_alt:"(loading)",page_info:"num_page_top - num_page_end of cnt",select_ng:"Attention : Please choose from among the list.",select_ok:"OK : Correctly selected."};break;case "es":a={add_btn:"Agregar boton",add_title:"Agregar una opcion",
del_btn:"Borrar boton",del_title:"Borrar una opcion",next:"Siguiente",next_title:"Proximas "+c.per_page+" (tecla derecha)",prev:"Anterior",prev_title:"Anteriores "+c.per_page+" (tecla izquierda)",first_title:"Primera (Shift + Left)",last_title:"Ultima (Shift + Right)",get_all_btn:"Ver todos (tecla abajo)",get_all_alt:"(boton)",close_btn:"Cerrar (tecla TAB)",close_alt:"(boton)",loading:"Cargando...",loading_alt:"(Cargando)",page_info:"num_page_top - num_page_end de cnt",select_ng:"Atencion: Elija una opcion de la lista.",
select_ok:"OK: Correctamente seleccionado."}}var d=null;this.each(function(){d=new b.ajaxComboBox(this,f,c,a)});this.data("ajc",d);return this}};b.fn.ajc=function(){return this.data("ajc")}})(jQuery);