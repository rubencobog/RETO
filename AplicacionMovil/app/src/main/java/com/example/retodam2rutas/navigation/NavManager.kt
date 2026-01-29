package com.example.retodam2rutas.navigation

import androidx.compose.runtime.Composable
import androidx.navigation.NavType
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import androidx.navigation.navArgument
import com.example.retodam2rutas.views.HomeView

@Composable
fun NavManager(){
    val navController = rememberNavController()
    NavHost(navController = navController,
        startDestination = "Home"){
        composable("Home"){
            HomeView(navController)
        }
//        composable ("Detail/{id}",
//            arguments = listOf(navArgument("id"){type = NavType.IntType})){
//                backStackEntry ->
//            val id = backStackEntry.arguments?.getInt("id") ?:0
//            DetailView(navController, id)
//        }
    }
}