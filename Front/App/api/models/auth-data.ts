import {RoleName} from "../../constants/role-name";

export default interface AuthData {
    readonly token?: string;
    readonly email: string;
    readonly roles: RoleName[];
}