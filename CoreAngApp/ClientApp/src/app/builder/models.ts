export interface FieldOption {
    label: string;
    value: string;
  }
  
  export interface Field {
    name: string;
    type: string;
    label: string;
    required: boolean;
    options: FieldOption[];
    //cell: string;
    //cellExp: (element: any) => string;
  }
  
  export interface GenForm {
    title: string;
    name:string;
    fields?: Field[];
    displayedColumns?:string[];
  }
  
  export interface RootObject {
    Application: string;
    forms: GenForm[];
    
  }
  
  export const defaultObject: RootObject = {
    Application: 'My Application',
    forms: [
      {
        title: 'My Form',
        name:'myform',
        displayedColumns:["field1", "field2", "field3"],
        fields: [
          {
            name: 'field1',
            type: 'text',
            label: 'Field 1',
            required: true,
            options: [],
            //cellExp: (element: any) => `${element.field1}`,
            //cell:'(row: any) => `${row.field1}`'
          },
          {
            name: 'field2',
            type: 'textarea',
            label: 'Field 2',
            required: false,
            options: [],
            //cell:`${row.field2}`
            //cellExp: (element: any) => `${element.field2}`,
       
            
          },
          {
            name: 'field3',
            type: 'select',
            label: 'Field 3',
            required: true,
            //cellExp: (element: any) => `${element.field2}`,       
            //cell:'(row: any) => `${row.field3}`',
            options: [
              { label: 'Option 1', value: '1' },
              { label: 'Option 2', value: '2' },
              { label: 'Option 3', value: '3' }
            ]
          }
        ]
      }
    ]
  };
  