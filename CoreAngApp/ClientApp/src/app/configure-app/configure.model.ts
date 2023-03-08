export interface cfFormField {
    name: string;
    type: string;
    label: string;
    options?: cfOption[];
    required: boolean;
  }
  
  export interface cfForm {
    title: string;
    name: string;
    displayedColumns: string[];
    fields: cfFormField[];
  }
  
  export interface cfOption {
    label: string;
    value: string;
  }
  
  export interface cfApplication {
    name: string;
    forms: cfForm[];
  }
  