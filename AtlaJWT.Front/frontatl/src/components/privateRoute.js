import React from 'react'
import { Route, Redirect, Navigate } from 'react-router'
import isAutorize from '../shared/token'
import ListPage from './listpage'

const PrivateRoute = props => isAutorize() ?
    <Route element={<ListPage />} />
    : <Navigate replace to="/" />

export default PrivateRoute;