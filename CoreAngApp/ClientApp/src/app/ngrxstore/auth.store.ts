import { State, Action, StateContext } from '@ngxs/store';
import { TokenData } from '../core/models/response.model';
export class LoginAction {
    static readonly type = '[Auth] Login';
    constructor(public payload: TokenData) {}
  }
export interface LoginStateModel {
  accessToken: string;
  refreshToken: string;
  userName: string;
  expiresIn: number;
}

@State<LoginStateModel>({
  name: 'login',
  defaults: {
    accessToken: '',
    refreshToken: '',
    userName: '',
    expiresIn: 0,
  }
})
export class LoginState {
  @Action(LoginAction)
  login(ctx: StateContext<LoginStateModel>, { payload }: LoginAction) {
    console.log(payload);
    ctx.patchState({
      accessToken: payload.accessToken,
      refreshToken: payload.refreshToken.token,
      userName: payload.userName,
      expiresIn: payload.tokenLifeTime,
    });
  }
}
