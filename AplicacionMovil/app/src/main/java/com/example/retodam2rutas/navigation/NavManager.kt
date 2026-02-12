package com.example.retodam2rutas.navigation

import androidx.compose.runtime.Composable
import androidx.navigation.NavType
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import androidx.navigation.navArgument
import com.example.retodam2rutas.views.LoginViewModel
import com.example.retodam2rutas.views.DetailView
import com.example.retodam2rutas.views.HomeView
import com.example.retodam2rutas.views.LoginView
import com.example.retodam2rutas.views.AddRutaView
import com.example.retodam2rutas.views.MapViewModel
import com.example.retodam2rutas.views.RutaViewModel

@Composable
fun NavManager(rutaViewModel: RutaViewModel, mapViewModel: MapViewModel, loginViewModel: LoginViewModel){
    val navController = rememberNavController()
    NavHost(navController = navController,
        startDestination = "Login"){
        composable("Home"){
            HomeView(navController, rutaViewModel)
        }
        composable("Add"){
            AddRutaView(navController, 1, rutaViewModel, mapViewModel, loginViewModel)
        }
        composable ("Detail/{id}",
            arguments = listOf(navArgument("id"){type = NavType.IntType})){
                backStackEntry ->
            val id = backStackEntry.arguments?.getInt("id") ?:0
            DetailView(navController, id, rutaViewModel)
        }
        composable ("Map/{id}",
            arguments = listOf(navArgument("id"){type = NavType.IntType})){
                backStackEntry ->
            val id = backStackEntry.arguments?.getInt("id") ?:0
            AddRutaView(navController, id, rutaViewModel, mapViewModel, loginViewModel)
        }
        composable("Login"){
            LoginView(navController, loginViewModel)
        }
    }
}