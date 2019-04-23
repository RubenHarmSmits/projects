import JWT from 'jsonwebtoken'

import axios from '../../http'

export const logout = () => {
        return axios.post("Auth/Logout")
}

export const externalLogin = (provider, token, profile) => {
    return new Promise((resolve, reject) => {
        axios.post("Auth/ExternalLogin", {
            provider,
            idToken: token
        }).then(res => {
            let refreshToken = res.data.refreshToken
            let accessToken = res.data.accessToken
            let apiUser = JWT.decode(accessToken)

            resolve({
                accessToken,
                refreshToken,
                apiId: apiUser.nameid,
                apiRole: apiUser.role,
                name: profile.getGivenName(),
                fullName: profile.getName(),
                email: profile.getEmail(),
                image: profile.getImageUrl()
            });
        }).catch(err => {
            // For now just return the first error
            if (err.response && err.response.data.errors) {
                reject(new Error(
                    Object.values(err.response.data.errors)[0]
                ))
            }
            reject(err)
        })
    })
}