"use strict";(self.webpackChunkngx_admin=self.webpackChunkngx_admin||[]).push([[592],{850:(C,_,r)=>{r.d(_,{E:()=>h});var u=r(457),a=r(3900),m=r(4004),E=r(4650);let h=(()=>{class s{constructor(){}getConfigData(){return(0,u.D)(fetch("./assets/formconfig.json")).pipe((0,a.w)(o=>o.json()),(0,m.U)(o=>{const t=[];return o.forms.forEach(n=>{const c=[];n?.fields?.forEach(e=>{const p=e?.options?.map(l=>({label:l.label,value:l.value}));c.push({name:e.name,type:e.type,label:e.label,required:e.required,options:p})}),t.push({title:n.title,name:n.name,fields:c})}),{Application:o.Application,forms:t}}))}getConfigData2(){return(0,u.D)(fetch("./assets/formconfig.json")).pipe((0,a.w)(o=>o.json()),(0,m.U)(o=>{const t=[];return o.forms.forEach(n=>{const c=[];n?.fields?.forEach(e=>{const p=e?.options?.map(l=>({label:l.label,value:l.value}));c.push({name:e.name,type:e.type,label:e.label,required:e.required,options:p})}),t.push({title:n.title,name:n.name,fields:c,displayedColumns:[]})}),{name:o.name,forms:t}}))}}return s.\u0275fac=function(o){return new(o||s)},s.\u0275prov=E.Yz7({token:s,factory:s.\u0275fac,providedIn:"root"}),s})()}}]);