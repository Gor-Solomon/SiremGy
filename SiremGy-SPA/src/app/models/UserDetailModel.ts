import { UserModel } from './userModel';
import { PhotoModel } from './PhotoModel';

export interface UserDetailModel {
    Id: number;
    Nickname: string;
    Gender: string;
    Age: number;
    Country: string;
    City: string;
    Address: string;
    Introduction: string;
    LookingFor: string;
    Intrests: string;
    Birthday?: Date;
    User?: UserModel;
    Photo?: PhotoModel;
    Photos?: PhotoModel[];
}
