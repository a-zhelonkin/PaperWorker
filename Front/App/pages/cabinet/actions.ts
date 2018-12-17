import {createStandardAction} from "typesafe-actions";
import {Profile} from "./cabinet.api";

const PROFILE_LOAD: string = "cabinet/PROFILE_LOAD";

export const loadProfile = createStandardAction(PROFILE_LOAD)<Profile>();
