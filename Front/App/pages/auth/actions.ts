import {createAction, createStandardAction} from "typesafe-actions";

const TOKEN_UPDATE: string = "auth/TOKEN_UPDATE";
const EMAIL_UPDATE: string = "auth/EMAIL_UPDATE";
const LOGOUT: string = "auth/LOGOUT";

export const updateToken = createStandardAction(TOKEN_UPDATE)<string>();

export const updateEmail = createStandardAction(EMAIL_UPDATE)<string>();

export const logout = createAction(LOGOUT);
