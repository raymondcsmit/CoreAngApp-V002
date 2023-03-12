
import { ComponentFactoryResolver, ComponentRef, Injectable, ViewChild, ViewContainerRef } from "@angular/core";
import { BaseComponent } from "./base.component";
import { FormComponent } from "./form.component";
import { ListAgGridComponent } from "./list-ag-grid.component";


export interface ComponentFactory {
  createComponent(): ComponentRef<BaseComponent>;
}

// FormComponentFactory.ts

@Injectable({
    providedIn: 'root'
  })
export class FormComponentFactory implements ComponentFactory {
  constructor() {}
  @ViewChild('genComponent', { read: ViewContainerRef }) genComponent!: ViewContainerRef;
  createComponent(): ComponentRef<BaseComponent> {
    const component =this.genComponent.createComponent(FormComponent);
    return component;
  }
}

@Injectable({
    providedIn: 'root'
  })
export class ListAgGridComponentFactory implements ComponentFactory {
  constructor() {}
  @ViewChild('genComponent', { read: ViewContainerRef }) genComponent!: ViewContainerRef;
  createComponent(): ComponentRef<BaseComponent> {
    const component =this.genComponent.createComponent(ListAgGridComponent);
    return component;
  }
}



@Injectable({
  providedIn: 'root'
})
export class ComponentFactoryResolverService {
  private factories = new Map<string, ComponentFactory>();

  constructor() {
    this.factories.set('Form', new FormComponentFactory());
    this.factories.set('List', new ListAgGridComponentFactory());
  }

  createComponentByType(type: string): ComponentRef<BaseComponent> {
    const componentFactory = this.factories.get(type);
    if (!componentFactory) {
      throw new Error(`Unsupported component type: ${type}`);
    }
    return componentFactory.createComponent();
  }
}



/*

@Component({
  selector: "app-root",
  template: `
    <ng-container #container></ng-container>
  `,
})
export class AppComponent {
  @ViewChild("container", { read: ViewContainerRef, static: true }) container!: ViewContainerRef;

  componentRef: ComponentRef<BaseComponent> | undefined;

  constructor(private componentFactoryResolverService: ComponentFactoryResolverService) {}

  generateComponent(type: string) {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const componentFactory = this.componentFactoryResolverService.createComponentByType(type);
    this.componentRef = this.container.createComponent(componentFactory);
  }
}
*/