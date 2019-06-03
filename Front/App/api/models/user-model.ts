import {UserStatus} from "../../constants/user-status";

export default interface UserModel {
    readonly id: string;
    readonly email: string;
    readonly status: UserStatus;
    readonly firstName: string;
    readonly lastName: string;
    readonly patronymic: string;
    readonly phoneNumber: string;
}