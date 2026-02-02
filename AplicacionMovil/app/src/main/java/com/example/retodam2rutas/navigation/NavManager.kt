package com.example.retodam2rutas.navigation

import androidx.compose.runtime.Composable
import androidx.navigation.NavType
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import androidx.navigation.navArgument
import com.example.retodam2rutas.views.DetailView
import com.example.retodam2rutas.views.HomeView
import com.example.retodam2rutas.views.RutaViewModel

@Composable
fun NavManager(rutaViewModel: RutaViewModel){
    val navController = rememberNavController()
    NavHost(navController = navController,
        startDestination = "Home"){
        composable("Home"){
            HomeView(navController, rutaViewModel)
        }
        composable("Add"){
            HomeView(navController, rutaViewModel)
        }
        composable ("Detail/{id}",
            arguments = listOf(navArgument("id"){type = NavType.IntType})){
                backStackEntry ->
            val id = backStackEntry.arguments?.getInt("id") ?:0
            DetailView(navController, id, rutaViewModel)
        }
    }
}