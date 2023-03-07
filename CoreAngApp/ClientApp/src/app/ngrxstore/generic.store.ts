import { Action, createAction, createReducer, on, props ,createFeatureSelector, createSelector} from '@ngrx/store';

export interface GenericState<T> {
    entities: { [key: string]: T[] };
    loading: { [key: string]: boolean };
    error: { [key: string]: any };
  }
  const initialState: GenericState<any> = {
    entities: {},
    loading: {},
    error: {}
  };
  
  
  export const createGenericData = createAction(
    '[Generic] Create Data',
    props<{ key: string, payload: any }>()
  );
  
  export const updateGenericData = createAction(
    '[Generic] Update Data',
    props<{ key: string, id: string, payload: any }>()
  );
  
  export const deleteGenericData = createAction(
    '[Generic] Delete Data',
    props<{ key: string, id: string ,payload: any}>()
  );
  export const loadGenericData = createAction(
    '[Generic] Load Data',
    props<{ key: string }>()
  );
  
  export const loadGenericDataSuccess = createAction(
    '[Generic] Load Data Success',
    props<{ key: string, payload: any[] }>()
  );
  
  export const loadGenericDataFailure = createAction(
    '[Generic] Load Data Failure',
    props<{ key: string, payload: any }>()
  );

  

export const genericReducer = createReducer(
  initialState,
  on(loadGenericData, (state, { key }) => ({
    ...state,
    loading: {
      ...state.loading,
      [key]: true
    },
    error: {
      ...state.error,
      [key]: null
    }
  })),
  on(loadGenericDataSuccess, (state, { key, payload }) => ({
    ...state,
    entities: {
      ...state.entities,
      [key]: payload
    },
    loading: {
      ...state.loading,
      [key]: false
    },
    error: {
      ...state.error,
      [key]: null
    }
  })),
  on(loadGenericDataFailure, (state, { key, payload }) => ({
    ...state,
    loading: {
      ...state.loading,
      [key]: false
    },
    error: {
      ...state.error,
      [key]: payload
    }
  }))
);

export function reducer(state: GenericState<any>, action: Action) {
  return genericReducer(state, action);
}




export const selectGenericState = createFeatureSelector<GenericState<any>>('generic');

export const selectGenericEntity = <T>(key: string) =>
  createSelector(
    selectGenericState,
    (state: GenericState<T>) => state.entities[key] || []
  );

export const selectGenericData = <T>(key: string) =>
  createSelector(
    selectGenericEntity<T>(key),
    (entities: T[]) => entities
  );

export const selectGenericLoading = (key: string) =>
  createSelector(
    selectGenericState,
    (state: GenericState<any>) => state.loading[key] || false
  );

export const selectGenericError = (key: string) =>
  createSelector(
    selectGenericState,
    (state: GenericState<any>) => state.error[key]
  );
