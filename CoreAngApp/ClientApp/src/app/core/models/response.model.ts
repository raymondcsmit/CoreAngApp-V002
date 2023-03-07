export interface LoginResponse {
    success: boolean;
    isSuccess: boolean;
    message: string;
    statusCode: number;
    data: TokenData;
    recordsEffected: number;
    totalRecords: number;
  }
  export interface TokenData{
    
        accessToken: string;
        tokenLifeTime: number;
        refreshToken: RefreshToken;
        userName: string;
        message: string;
        expireDate: any;
        expireTime: any;
    
  }
  export interface RefreshToken{
    token: string;
    expiry: string;
    isExpired: boolean;
    created: string;
    createdByIp: string;
    revoked: any;
    revokedByIp: any;
    replacedByToken: any;
    userId: string;
    isActive: boolean;
  }
  