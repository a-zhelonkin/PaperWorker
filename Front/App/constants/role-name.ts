export enum RoleName {

    Admin = "Admin",

    Consumer = "Consumer",

    Locksmith = "Locksmith"

}

export interface RoleNameDetails {
    readonly name: string;
}

export const roleNameDetails: { [role: string]: RoleNameDetails } = {
    [RoleName.Admin]: {
        name: "Администратор"
    },
    [RoleName.Consumer]: {
        name: "Потребитель"
    },
    [RoleName.Locksmith]: {
        name: "Слесарь"
    }
};