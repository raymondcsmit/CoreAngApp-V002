"use strict";(self.webpackChunkngx_admin=self.webpackChunkngx_admin||[]).push([[218],{5282:(q,C,s)=>{s.r(C),s.d(C,{CompBuilderModule:()=>k});var g=s(6895),n=s(4650),d=s(4006);const t_forms=[{title:"My Form",name:"myform",displayedColumns:["field1","field2","field3"],fields:[{name:"field1",type:"text",label:"Field 1",required:!0,options:[]},{name:"field2",type:"textarea",label:"Field 2",required:!1,options:[]},{name:"field3",type:"select",label:"Field 3",required:!0,options:[{label:"Option 1",value:"1"},{label:"Option 2",value:"2"},{label:"Option 3",value:"3"}]}]}];let T=(()=>{class a{constructor(e){this.fb=e,this.configuration=t_forms[0],this.formName="defaultname",this.unique_key=0,this.form=this.fb.group({})}}return a.\u0275fac=function(e){return new(e||a)(n.Y36(d.qu))},a.\u0275cmp=n.Xpm({type:a,selectors:[["app-base"]],decls:2,vars:0,template:function(e,i){1&e&&(n.TgZ(0,"p"),n._uU(1,"Base Component"),n.qZA())},encapsulation:2}),a})();var f=s(6897),m=s(784),x=s(529);function h(a,c){1&a&&(n.TgZ(0,"div"),n._uU(1,"Loading..."),n.qZA())}function O(a,c){if(1&a&&(n.TgZ(0,"div"),n._uU(1),n.ALo(2,"async"),n.qZA()),2&a){const e=n.oxw();n.xp6(1),n.hij("Error: ",n.lcZ(2,1,e.error$),"")}}function Z(a,c){if(1&a&&n._UZ(0,"input",7),2&a){const e=n.oxw().$implicit;n.Q6J("type",e.type)("formControlName",e.name)}}function w(a,c){if(1&a&&n._UZ(0,"textarea",8),2&a){const e=n.oxw().$implicit;n.Q6J("formControlName",e.name)}}function A(a,c){if(1&a&&(n.TgZ(0,"option",10),n._uU(1),n.qZA()),2&a){const e=c.$implicit;n.Q6J("value",e.value),n.xp6(1),n.hij(" ",e.label," ")}}function P(a,c){if(1&a&&(n.TgZ(0,"select",8),n.YNc(1,A,2,2,"option",9),n.qZA()),2&a){const e=n.oxw().$implicit;n.Q6J("formControlName",e.name),n.xp6(1),n.Q6J("ngForOf",e.options)}}function F(a,c){if(1&a&&(n.TgZ(0,"div"),n._uU(1),n.qZA()),2&a){const e=n.oxw(2).$implicit;n.xp6(1),n.hij(" ",e.label," is required. ")}}function b(a,c){if(1&a&&(n.TgZ(0,"div"),n.YNc(1,F,2,1,"div",1),n.qZA()),2&a){const e=n.oxw().$implicit,i=n.oxw();let o;n.xp6(1),n.Q6J("ngIf",null==(o=i.form.get(e.name))?null:o.errors.required)}}function v(a,c){if(1&a&&(n.TgZ(0,"div")(1,"label",3),n._uU(2),n.qZA(),n.TgZ(3,"div",4),n.YNc(4,Z,1,2,"input",5),n.YNc(5,w,1,1,"textarea",6),n.YNc(6,P,2,2,"select",6),n.qZA(),n.YNc(7,b,2,1,"div",1),n.qZA()),2&a){const e=c.$implicit,i=n.oxw();let o;n.xp6(1),n.Q6J("for",e.name),n.xp6(1),n.Oqu(e.label),n.xp6(1),n.Q6J("ngSwitch",e.type),n.xp6(1),n.Q6J("ngSwitchCase","text"),n.xp6(1),n.Q6J("ngSwitchCase","textarea"),n.xp6(1),n.Q6J("ngSwitchCase","select"),n.xp6(1),n.Q6J("ngIf",(null==(o=i.form.get(e.name))?null:o.invalid)&&((null==(o=i.form.get(e.name))?null:o.dirty)||(null==(o=i.form.get(e.name))?null:o.touched)))}}let S=(()=>{class a extends T{constructor(e,i,o){super(e),this.http=i,this.store=o,this.key=this.configuration?.name}ngOnInit(){this.store.dispatch((0,m.Dr)({key:this.key})),this.loading$=this.store.pipe((0,f.Ys)((0,m.gB)(this.key))),this.error$=this.store.pipe((0,f.Ys)((0,m.Ry)(this.key))),this.store.pipe((0,f.Ys)((0,m.su)(this.key))).subscribe(e=>{this.form=this.createForm(e[0])})}createForm(e){const i={};if(this.configuration?.fields){for(const l of this.configuration.fields)i[l.name]=new d.NI("",this.getValidators(l));const o=new d.cw(i);return e&&o.patchValue(e),o}return this.form}onSubmit(){const e=this.form.value;this.store.dispatch(e.id?(0,m.Fz)({key:this.key,id:e.id,payload:e}):(0,m.x1)({key:this.key,payload:e}))}onDelete(e){this.store.dispatch((0,m.Y6)({key:this.key,id:e,payload:{idx:e}}))}getValidators(e){const i=[];return e.required&&i.push(d.kI.required),i}}return a.\u0275fac=function(e){return new(e||a)(n.Y36(d.qu),n.Y36(x.eN),n.Y36(f.yh))},a.\u0275cmp=n.Xpm({type:a,selectors:[["app-form"]],inputs:{key:"key"},features:[n.qOj],decls:8,vars:9,consts:[[3,"formGroup","ngSubmit"],[4,"ngIf"],[4,"ngFor","ngForOf"],[3,"for"],[3,"ngSwitch"],[3,"type","formControlName",4,"ngSwitchCase"],[3,"formControlName",4,"ngSwitchCase"],[3,"type","formControlName"],[3,"formControlName"],[3,"value",4,"ngFor","ngForOf"],[3,"value"]],template:function(e,i){1&e&&(n.TgZ(0,"form",0),n.NdJ("ngSubmit",function(){return i.onSubmit()}),n.YNc(1,h,2,0,"div",1),n.ALo(2,"async"),n.YNc(3,O,3,3,"div",1),n.ALo(4,"async"),n.TgZ(5,"h3"),n._uU(6),n.qZA(),n.YNc(7,v,8,7,"div",2),n.qZA()),2&e&&(n.Q6J("formGroup",i.form),n.xp6(1),n.Q6J("ngIf",n.lcZ(2,5,i.loading$)),n.xp6(2),n.Q6J("ngIf",n.lcZ(4,7,i.error$)),n.xp6(3),n.Oqu(i.configuration.title),n.xp6(1),n.Q6J("ngForOf",i.configuration.fields))},dependencies:[g.sg,g.O5,g.RF,g.n9,d._Y,d.YN,d.Kr,d.Fj,d.EJ,d.JJ,d.JL,d.sg,d.u,g.Ov],encapsulation:2}),a})();var M=s(5715),I=s(850);const N=["genComponent"];function L(a,c){}let _=(()=>{class a{constructor(e,i,o){this.cdRef=e,this.route=i,this.configsrv=o,this.formComponents={}}ngOnInit(){}ngAfterViewInit(){this.route.paramMap.subscribe(e=>{const i=e.get("formname");this.configsrv.getConfigData().subscribe(o=>{const l=o.forms.find(r=>r.name===i);if(l){let r=this.formComponents[i];r?(r.instance.configuration=l,r.instance.formData=this.data):(r=this.genComponent.createComponent(S),r.instance.configuration=l,r.instance.formName=l.name,r.instance.formData=this.data,this.formComponents[i]=r);for(const[p,u]of Object.entries(this.formComponents))p!==i&&(u.location.nativeElement.style.display="none");r.location.nativeElement.style.display="block"}else{let r=this.formComponents[i];r&&(r.location.nativeElement.style.display="none",delete this.formComponents[i])}this.cdRef.detectChanges()})})}}return a.\u0275fac=function(e){return new(e||a)(n.Y36(n.sBO),n.Y36(M.gz),n.Y36(I.E))},a.\u0275cmp=n.Xpm({type:a,selectors:[["wrdynamic-component"]],viewQuery:function(e,i){if(1&e&&n.Gf(N,5,n.s_b),2&e){let o;n.iGM(o=n.CRH())&&(i.genComponent=o.first)}},inputs:{data:"data"},decls:2,vars:0,consts:[["genComponent",""]],template:function(e,i){1&e&&n.YNc(0,L,0,0,"ng-template",null,0,n.W1O)},encapsulation:2}),a})();var y=s(4519),U=s(749);const D=[{path:"",component:_}];let k=(()=>{class a{}return a.\u0275fac=function(e){return new(e||a)},a.\u0275mod=n.oAB({type:a}),a.\u0275inj=n.cJS({imports:[g.ez,y.I,U.m,d.UX,M.Bz.forChild(D)]}),a})()},4218:(q,C,s)=>{s.r(C),s.d(C,{DashboardModule:()=>c});var g=s(5282),n=s(749),d=s(5715),t=s(4650);let T=(()=>{class e{constructor(){}ngOnInit(){}}return e.\u0275fac=function(o){return new(o||e)},e.\u0275cmp=t.Xpm({type:e,selectors:[["app-footer"]],decls:3,vars:0,consts:[[1,"content__footer"],["id","license-footer"]],template:function(o,l){1&o&&(t.TgZ(0,"div",0)(1,"div",1),t._uU(2," WaqarHabib \xa92023 "),t.qZA()())},styles:[".content__footer[_ngcontent-%COMP%]   #license-footer[_ngcontent-%COMP%]{padding:16px 32px;text-align:center;border-top:1px solid #ddd;font-size:62.5%;line-height:1.4}.content__footer[_ngcontent-%COMP%]   #license-footer[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]{text-decoration:none;color:#ff5252}"]}),e})();var f=s(6895),m=s(4859),x=s(7392),h=s(3683);const O=["sidenav"];function Z(e,i){if(1&e){const o=t.EpF();t.TgZ(0,"button",8),t.NdJ("click",function(){t.CHM(o);const r=t.oxw();return t.KtG(r.toggle())}),t.TgZ(1,"mat-icon"),t._uU(2,"arrow_back"),t.qZA()()}}const w=["*"];let P=(()=>{class e{onResize(o){this.changeToResponsiveViewIfNeed(o.target.innerWidth)}constructor(){this.isFixed=!1,this.isOpen=!0}ngAfterViewInit(){this.changeToResponsiveViewIfNeed(window.innerWidth),this.setMenusExperienceScripts()}setMenusExperienceScripts(){const o=this.sidenavElement.nativeElement.querySelectorAll(".submenu");this.sidenavElement.nativeElement.querySelectorAll("dl:not(.submenu) dt").forEach(r=>{r.addEventListener("click",p=>{o.forEach(u=>{u.classList.remove("open"),u.querySelector("dd").style.height="0"})})}),o.length>0&&o.forEach(r=>{r.setAttribute("default-height",`${r.querySelector("dd")?.clientHeight}`),r.querySelector("dd").style.height=0,r.querySelector("dt").addEventListener("click",()=>{r.classList.toggle("open");const p=r.querySelector("dd");p.style.height="0px"===p.style.height?p.parentElement.getAttribute("default-height")+"px":0,[].slice.call(o).filter(u=>u!==r).map(u=>{u.querySelector("dd").style.height=0,u.classList.remove("open")})})})}toggle(){this.isOpen=!this.isOpen}changeToResponsiveViewIfNeed(o){o<=1280?(this.isOpen=!1,this.isFixed=!0):(this.isOpen=!0,this.isFixed=!1)}}return e.\u0275fac=function(o){return new(o||e)},e.\u0275cmp=t.Xpm({type:e,selectors:[["app-sidenav"]],viewQuery:function(o,l){if(1&o&&t.Gf(O,7),2&o){let r;t.iGM(r=t.CRH())&&(l.sidenavElement=r.first)}},hostBindings:function(o,l){1&o&&t.NdJ("resize",function(p){return l.onResize(p)},!1,t.Jf7)},ngContentSelectors:w,decls:11,vars:5,consts:[[1,"sidenav"],["sidenav",""],[1,"sidenav-header"],[1,"logo"],["src","data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAyNTAgMjUwIj4KICAgIDxwYXRoIGZpbGw9IiNERDAwMzEiIGQ9Ik0xMjUgMzBMMzEuOSA2My4ybDE0LjIgMTIzLjFMMTI1IDIzMGw3OC45LTQzLjcgMTQuMi0xMjMuMXoiIC8+CiAgICA8cGF0aCBmaWxsPSIjQzMwMDJGIiBkPSJNMTI1IDMwdjIyLjItLjFWMjMwbDc4LjktNDMuNyAxNC4yLTEyMy4xTDEyNSAzMHoiIC8+CiAgICA8cGF0aCAgZmlsbD0iI0ZGRkZGRiIgZD0iTTEyNSA1Mi4xTDY2LjggMTgyLjZoMjEuN2wxMS43LTI5LjJoNDkuNGwxMS43IDI5LjJIMTgzTDEyNSA1Mi4xem0xNyA4My4zaC0zNGwxNy00MC45IDE3IDQwLjl6IiAvPgogIDwvc3ZnPg==",1,"logo-icon"],[1,"logo-text","secondary-text"],["mat-icon-button","","aria-label","",3,"click",4,"ngIf"],[1,"sidenav-menu"],["mat-icon-button","","aria-label","",3,"click"]],template:function(o,l){1&o&&(t.F$t(),t.TgZ(0,"div",0,1)(2,"mat-toolbar",2)(3,"mat-toolbar-row")(4,"div",3),t._UZ(5,"img",4),t.TgZ(6,"span",5),t._uU(7,"WR Mat"),t.qZA()(),t.YNc(8,Z,3,0,"button",6),t.qZA()(),t.TgZ(9,"div",7),t.Hsn(10),t.qZA()()),2&o&&(t.ekj("closed",!l.isOpen)("fixed",l.isFixed),t.xp6(8),t.Q6J("ngIf",l.isFixed))},dependencies:[f.O5,m.RK,x.Hw,h.Ye,h.rD],styles:['[_nghost-%COMP%]{height:auto;min-height:100%}.sidenav[_ngcontent-%COMP%]{background-color:#2d323e;box-sizing:border-box;height:auto;min-height:100%;width:280px;min-width:280px;overflow:auto;overflow-x:hidden;box-shadow:0 0 1px 1px #00000024,0 0 2px 2px #00000019,0 0 5px 1px #00000015;transition:width .35s,min-width .35s}.sidenav[_ngcontent-%COMP%]     .sidenav-header{display:flex;flex-direction:row;flex:1 0 auto;align-items:center;justify-content:space-between;background-color:#363c4a;color:#ffffffde;box-shadow:0 2px 1px -1px #0003,0 1px 1px #00000024,0 1px 3px #0000001f}.sidenav[_ngcontent-%COMP%]     .sidenav-header .mat-toolbar-row{justify-content:space-between}.sidenav[_ngcontent-%COMP%]     .sidenav-header .mat-toolbar-row .logo{display:flex;align-items:center}.sidenav[_ngcontent-%COMP%]     .sidenav-header .mat-toolbar-row .logo .logo-icon{width:32px}.sidenav[_ngcontent-%COMP%]     .sidenav-header .mat-toolbar-row .logo .logo-text{margin-left:12px;font-size:16px;font-weight:400;letter-spacing:.4px;line-height:normal}.sidenav[_ngcontent-%COMP%]     .sidenav-header .mat-toolbar-row button{color:#ffffffb3!important}.sidenav[_ngcontent-%COMP%]     .sidenav-menu{padding-top:16px;font-size:14px!important}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl{margin:0;white-space:nowrap}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl dt{padding:16px;color:#ffffffde;cursor:pointer;outline:none}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl dt:hover{background-color:#292d38}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl dt.active{background-color:#039be5}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl.submenu{transition:all .4s}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl.submenu dt{display:flex;justify-content:space-between}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl.submenu dt:after{font-family:Material Icons;content:"expand_more";transition:all .4s ease;display:flex;align-items:center}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl.submenu dd{margin:0;background-color:#242832;overflow:hidden;transition:height .4s}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl.submenu dd a{color:#ffffffde;display:block;letter-spacing:.1px;overflow:hidden;padding:16px 16px 16px 18px;text-overflow:ellipsis;white-space:nowrap;text-decoration:none;cursor:pointer}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl.submenu dd a.active{background-color:#039be5}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl.submenu.open{background-color:#242832}.sidenav[_ngcontent-%COMP%]     .sidenav-menu dl.submenu.open dt:after{transform:rotate(-180deg)}.sidenav.fixed[_ngcontent-%COMP%]{position:absolute;transform:translateZ(0);transition:transform .35s;z-index:9}.sidenav.fixed.closed[_ngcontent-%COMP%]{width:300px;min-width:300px;transform:translate3d(-100%,0,0)}.sidenav.closed[_ngcontent-%COMP%]{width:0;min-width:0;box-shadow:none}']}),e})();var F=s(263),b=s(4850),v=s(8255),S=s(1576),M=s(5829);let I=(()=>{class e{constructor(o,l){this.authService=o,this.router=l,this.sidenavToggle=new t.vpe}ngOnInit(){}onToggeleSidenav(){this.sidenavToggle.emit()}onLogout(){this.authService.logout(),this.router.navigate(["auth/login"])}onFullscreenToggle(){const o=document.querySelector(".dashboard");o.requestFullscreen?o.requestFullscreen():o.webkitRequestFullScreen?o.webkitRequestFullScreen():o.mozRequestFullScreen?o.mozRequestFullScreen():o.msRequestFullScreen&&o.msRequestFullScreen()}}return e.\u0275fac=function(o){return new(o||e)(t.Y36(F.e),t.Y36(d.F0))},e.\u0275cmp=t.Xpm({type:e,selectors:[["app-toolbar"]],outputs:{sidenavToggle:"sidenavToggle"},decls:51,vars:4,consts:[[1,"toolbar"],["mat-button","",1,"side-nav-toggle",3,"click"],["fxFlex",""],[1,"user-menu"],["mat-button","",3,"matMenuTriggerFor"],["src","assets/images/avatars/profile.jpg","alt","User Image"],["fxHide.lt-md",""],["fxHide.lt-sm",""],["xPosition","before","yPosition","above",3,"overlapTrigger"],["menu","matMenu"],["mat-menu-item","",2,"min-width","194px"],["mat-menu-item","","disabled",""],["mat-menu-item","",3,"click"],["mat-button","",1,"settings",3,"matMenuTriggerFor"],["src","assets/images/flags/us.png",2,"margin-right","8px"],["menuLanguage","matMenu"],["mat-menu-item",""],["src","assets/images/flags/tr.png",2,"margin-right","8px"],["mat-button","",1,"settings",3,"click"],["mat-button","",1,"settings"]],template:function(o,l){if(1&o&&(t.TgZ(0,"mat-toolbar",0)(1,"mat-toolbar-row")(2,"button",1),t.NdJ("click",function(){return l.onToggeleSidenav()}),t.TgZ(3,"mat-icon"),t._uU(4," menu "),t.qZA()(),t._UZ(5,"span",2),t.TgZ(6,"div",3)(7,"button",4),t._UZ(8,"img",5),t.TgZ(9,"span",6),t._uU(10,"Administrator"),t.qZA(),t.TgZ(11,"mat-icon",7),t._uU(12,"keyboard_arrow_down"),t.qZA()(),t.TgZ(13,"mat-menu",8,9)(15,"button",10)(16,"mat-icon"),t._uU(17," person "),t.qZA(),t.TgZ(18,"span"),t._uU(19," Profile "),t.qZA()(),t.TgZ(20,"button",11)(21,"mat-icon"),t._uU(22," announcement "),t.qZA(),t.TgZ(23,"span"),t._uU(24," Notifications "),t.qZA()(),t._UZ(25,"mat-divider"),t.TgZ(26,"button",12),t.NdJ("click",function(){return l.onLogout()}),t.TgZ(27,"mat-icon"),t._uU(28," exit_to_app "),t.qZA(),t.TgZ(29,"span"),t._uU(30," Logout "),t.qZA()()()(),t.TgZ(31,"button",13),t._UZ(32,"img",14),t.TgZ(33,"span"),t._uU(34,"EN"),t.qZA()(),t.TgZ(35,"mat-menu",8,15)(37,"button",16),t._UZ(38,"img",14),t.TgZ(39,"span"),t._uU(40,"EN"),t.qZA()(),t.TgZ(41,"button",16),t._UZ(42,"img",17),t.TgZ(43,"span"),t._uU(44,"TR"),t.qZA()()(),t.TgZ(45,"button",18),t.NdJ("click",function(){return l.onFullscreenToggle()}),t.TgZ(46,"mat-icon"),t._uU(47,"fullscreen"),t.qZA()(),t.TgZ(48,"button",19)(49,"mat-icon"),t._uU(50,"format_list_bulleted"),t.qZA()()()()),2&o){const r=t.MAs(14),p=t.MAs(36);t.xp6(7),t.Q6J("matMenuTriggerFor",r),t.xp6(6),t.Q6J("overlapTrigger",!1),t.xp6(18),t.Q6J("matMenuTriggerFor",p),t.xp6(4),t.Q6J("overlapTrigger",!1)}},dependencies:[m.lW,b.d,x.Hw,v.VK,v.OP,v.p6,h.Ye,h.rD,S.yH,M.b8],styles:[".toolbar[_ngcontent-%COMP%]{box-shadow:0 0 1px 1px #00000024,0 0 2px 2px #00000019,0 0 5px 1px #00000015;background:#f6f6f6!important;color:#666!important}.toolbar[_ngcontent-%COMP%]   mat-toolbar-row[_ngcontent-%COMP%]{padding-right:0;padding-left:0}.toolbar[_ngcontent-%COMP%]   mat-toolbar-row[_ngcontent-%COMP%]   .side-nav-toggle[_ngcontent-%COMP%]{border-right:1px solid rgba(0,0,0,.12);height:100%;min-width:64px}.toolbar[_ngcontent-%COMP%]   mat-toolbar-row[_ngcontent-%COMP%]   .user-menu[_ngcontent-%COMP%]{height:100%}.toolbar[_ngcontent-%COMP%]   mat-toolbar-row[_ngcontent-%COMP%]   .user-menu[_ngcontent-%COMP%]   button[_ngcontent-%COMP%]{height:100%;border-left:1px solid rgba(0,0,0,.12)}.toolbar[_ngcontent-%COMP%]   mat-toolbar-row[_ngcontent-%COMP%]   .user-menu[_ngcontent-%COMP%]   button[_ngcontent-%COMP%]   img[_ngcontent-%COMP%]{height:35px;width:35px;float:left;border-radius:50%}.toolbar[_ngcontent-%COMP%]   mat-toolbar-row[_ngcontent-%COMP%]   .user-menu[_ngcontent-%COMP%]   button[_ngcontent-%COMP%]   span[_ngcontent-%COMP%]{margin-left:16px}.toolbar[_ngcontent-%COMP%]   mat-toolbar-row[_ngcontent-%COMP%]   .user-menu[_ngcontent-%COMP%]   button[_ngcontent-%COMP%]   mat-icon[_ngcontent-%COMP%]{color:#0000008a;margin-left:8px;font-size:16px!important;width:16px!important;height:16px!important;min-width:16px!important;min-height:16px!important;line-height:16px!important}.toolbar[_ngcontent-%COMP%]   mat-toolbar-row[_ngcontent-%COMP%]   .settings[_ngcontent-%COMP%]{border-left:1px solid rgba(0,0,0,.12);height:100%;min-width:64px}"]}),e})();const N=["appSideNav"],L=function(){return{exact:!0}};let _=(()=>{class e{constructor(){}ngOnInit(){}onSidenavToggle(){this.appSidenavComponent.toggle()}}return e.path=()=>["dashboard"],e.\u0275fac=function(o){return new(o||e)},e.\u0275cmp=t.Xpm({type:e,selectors:[["app-dashboard"]],viewQuery:function(o,l){if(1&o&&t.Gf(N,5),2&o){let r;t.iGM(r=t.CRH())&&(l.appSidenavComponent=r.first)}},decls:32,vars:2,consts:[[1,"dashboard"],["appSideNav",""],["routerLink","/dashboard/home","routerLinkActive","active"],["routerLink","/configure","routerLinkActive","active"],["routerLink","/dashboard/loadform/formOne","routerLinkActive","active"],["routerLink","/dashboard/loadform/formTwo","routerLinkActive","active"],["routerLink","/dashboard/customer","routerLinkActive","active"],[1,"submenu"],["routerLink","/dashboard/product","routerLinkActive","active",3,"routerLinkActiveOptions"],["routerLink","/dashboard/product/detail","routerLinkActive","active"],[1,"wrapper"],[3,"sidenavToggle"],[1,"content"],[1,"content__body"]],template:function(o,l){1&o&&(t.TgZ(0,"div",0)(1,"app-sidenav",null,1)(3,"dl")(4,"dt",2),t._uU(5,"Home"),t.qZA()(),t.TgZ(6,"dl")(7,"dt",3),t._uU(8,"Configure"),t.qZA()(),t.TgZ(9,"dl")(10,"dt",4),t._uU(11,"Form One"),t.qZA()(),t.TgZ(12,"dl")(13,"dt",5),t._uU(14,"Form Two"),t.qZA()(),t.TgZ(15,"dl")(16,"dt",6),t._uU(17,"Customer"),t.qZA()(),t.TgZ(18,"dl",7)(19,"dt"),t._uU(20,"Product"),t.qZA(),t.TgZ(21,"dd")(22,"a",8),t._uU(23," List "),t.qZA(),t.TgZ(24,"a",9),t._uU(25," Detalle "),t.qZA()()()(),t.TgZ(26,"div",10)(27,"app-toolbar",11),t.NdJ("sidenavToggle",function(){return l.onSidenavToggle()}),t.qZA(),t.TgZ(28,"div",12)(29,"div",13),t._UZ(30,"router-outlet"),t.qZA(),t._UZ(31,"app-footer"),t.qZA()()()),2&o&&(t.xp6(22),t.Q6J("routerLinkActiveOptions",t.DdM(1,L)))},dependencies:[T,P,I,d.lC,d.rH,d.Od],styles:[".dashboard[_ngcontent-%COMP%]{height:100%;min-height:100%;position:relative;box-sizing:border-box;display:flex;flex-direction:row}.dashboard[_ngcontent-%COMP%]   .wrapper[_ngcontent-%COMP%]{position:relative;overflow:auto;color:#000000de;background-color:#fff3;-webkit-backdrop-filter:blur(10px);backdrop-filter:blur(10px);margin:0;box-sizing:border-box;display:flex;flex-direction:column;flex:1}.dashboard[_ngcontent-%COMP%]   .wrapper[_ngcontent-%COMP%]   .content[_ngcontent-%COMP%]{overflow:auto;box-sizing:border-box;display:flex;flex-direction:column;flex:1}.dashboard[_ngcontent-%COMP%]   .wrapper[_ngcontent-%COMP%]   .content__body[_ngcontent-%COMP%]{flex:1;position:relative;box-sizing:border-box;overflow-y:auto;height:100%;max-height:100%}.dashboard[_ngcontent-%COMP%]   .wrapper[_ngcontent-%COMP%]   .content__footer[_ngcontent-%COMP%]   #license-footer[_ngcontent-%COMP%]{padding:16px 32px;text-align:center;border-top:1px solid #ddd;font-size:62.5%;line-height:1.4}.dashboard[_ngcontent-%COMP%]   .wrapper[_ngcontent-%COMP%]   .content__footer[_ngcontent-%COMP%]   #license-footer[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]{text-decoration:none;color:#ff5252}"]}),e})(),y=(()=>{class e{constructor(){}ngOnInit(){}}return e.\u0275fac=function(o){return new(o||e)},e.\u0275cmp=t.Xpm({type:e,selectors:[["app-home"]],decls:2,vars:0,template:function(o,l){1&o&&(t.TgZ(0,"h3"),t._uU(1,"HOME"),t.qZA())}}),e})();const U=[{path:"",component:_,children:[{path:"",redirectTo:"home",pathMatch:"full"},{path:"home",component:y},{path:"loadform/:formname",loadChildren:()=>Promise.resolve().then(s.bind(s,5282)).then(e=>e.CompBuilderModule)},{path:"customer",loadChildren:()=>s.e(138).then(s.bind(s,138)).then(e=>e.CustomerModule)}]}];let D=(()=>{class e{}return e.components=[_,y],e.\u0275fac=function(o){return new(o||e)},e.\u0275mod=t.oAB({type:e}),e.\u0275inj=t.cJS({imports:[d.Bz.forChild(U),d.Bz]}),e})();var k=s(9814);let a=(()=>{class e{}return e.\u0275fac=function(o){return new(o||e)},e.\u0275mod=t.oAB({type:e}),e.\u0275inj=t.cJS({imports:[f.ez,m.ot,b.t,x.Ps,v.Tx,h.g0,k.o9]}),e})(),c=(()=>{class e{}return e.\u0275fac=function(o){return new(o||e)},e.\u0275mod=t.oAB({type:e}),e.\u0275inj=t.cJS({imports:[n.m,a,D,g.CompBuilderModule]}),e})()}}]);