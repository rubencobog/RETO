package com.example.retodam2rutas.components

import androidx.compose.foundation.BorderStroke
import androidx.compose.foundation.background
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.unit.dp

data class BottomNavItem(
    val label: String,
    val icon: androidx.compose.ui.graphics.vector.ImageVector
)

@Composable
fun ButtonRuta(
    label: String,
    icon: Int,
    color: Color,
    onClick: () -> Unit
){
    IconButton(
        onClick = onClick,
        modifier = Modifier
            .size(60.dp)
            .background(
                color = color,
                shape = RoundedCornerShape(12.dp)
            )
    ) {
        Icon(
            painter = painterResource(icon),
            contentDescription = label,
            tint = Color.Black
        )
    }
}