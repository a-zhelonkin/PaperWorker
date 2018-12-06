import {createAction, createStandardAction} from "typesafe-actions";

const LOGIN: string = "auth/LOGIN";
const LOGOUT: string = "auth/LOGOUT";

export const login = createStandardAction(LOGIN)<string>();

export const logout = createAction(LOGOUT);
