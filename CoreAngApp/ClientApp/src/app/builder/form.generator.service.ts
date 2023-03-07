import { Injectable } from '@angular/core';
import { ComponentRef } from '@angular/core';
import { BaseComponent } from './base.component';

@Injectable({
  providedIn: 'root'
})
export class FormComponentService {
  private components: {[formName: string]: ComponentRef<BaseComponent>} = {};

  constructor() { }

  public addComponent(formName: string, component: ComponentRef<BaseComponent>) {
    this.components[formName] = component;
  }

  public getComponent(formName: string): ComponentRef<BaseComponent> | undefined {
    return this.components[formName];
  }

  public removeComponent(formName: string) {
    if (this.components[formName]) {
      this.components[formName].destroy();
      delete this.components[formName];
    }
  }
}
