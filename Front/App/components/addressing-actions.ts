import {createStandardAction} from "typesafe-actions";
import {AddressModel} from "../api/addresses-api";
import {StructureModel} from "../api/structures-api";
import {StreetModel} from "../api/streets-api";
import {LocalityModel} from "../api/localities-api";
import {TerritoryModel} from "../api/territories-api";

const ADDRESS_ADD: string = "addressing/ADDRESS_ADD";
const ADDRESSES_UPDATE: string = "addressing/ADDRESSES_UPDATE";
const STRUCTURE_ADD: string = "addressing/STRUCTURE_ADD";
const STRUCTURES_UPDATE: string = "addressing/STRUCTURES_UPDATE";
const STREET_ADD: string = "addressing/STREET_ADD";
const STREETS_UPDATE: string = "addressing/STREETS_UPDATE";
const LOCALITY_ADD: string = "addressing/LOCALITY_ADD";
const LOCALITIES_UPDATE: string = "addressing/LOCALITIES_UPDATE";
const TERRITORY_ADD: string = "addressing/TERRITORY_ADD";
const TERRITORIES_UPDATE: string = "addressing/TERRITORIES_UPDATE";

export const addAddress = createStandardAction(ADDRESS_ADD)<AddressModel>();
export const updateAddresses = createStandardAction(ADDRESSES_UPDATE)<AddressModel[]>();
export const addStructure = createStandardAction(STRUCTURE_ADD)<StructureModel>();
export const updateStructures = createStandardAction(STRUCTURES_UPDATE)<StructureModel[]>();
export const addStreet = createStandardAction(STREET_ADD)<StreetModel>();
export const updateStreets = createStandardAction(STREETS_UPDATE)<StreetModel[]>();
export const addLocality = createStandardAction(LOCALITY_ADD)<LocalityModel>();
export const updateLocalities = createStandardAction(LOCALITIES_UPDATE)<LocalityModel[]>();
export const addTerritory = createStandardAction(TERRITORY_ADD)<TerritoryModel>();
export const updateTerritories = createStandardAction(TERRITORIES_UPDATE)<TerritoryModel[]>();
