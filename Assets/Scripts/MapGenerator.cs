﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int rows;
    public int columns;

    private float roomWidth = 50f;
    private float roomHeight = 50f;

    public GameObject[] gridPrefabs;

    private Room[,] grid;

    private void Start()
    {
        GenerateGrid();
    }

    public GameObject RandomRoomPrefab()
    {
        return gridPrefabs[Random.Range(0, gridPrefabs.Length)];
    }

    public void GenerateGrid()
    {
        // Clear out the grid - "which column" is our X, "which row" is our Y
        grid = new Room[columns, rows];

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                float xPosition = column * roomWidth;
                float zPosition = row * roomHeight;

                Vector3 newRoomPosition = new Vector3(xPosition, 0f, zPosition);

                GameObject temporaryRoom = Instantiate(RandomRoomPrefab(), newRoomPosition, Quaternion.identity);

                Room currentRoom = temporaryRoom.GetComponent<Room>();
                // Open the doors
                // If we are on the bottom row, open the north door
                // If we're not the top row, open the north door.
                if (row != rows-1)
                {
                    currentRoom.doorNorth.SetActive(false);
                }
                if (row != 0)
                {
                    currentRoom.doorSouth.SetActive(false);
                }
                // TODO: Fix the East and West doors below.
                // If we are on the first column, open the east door
                if (row == 0)
                {
                    currentRoom.doorEast.SetActive(false);
                }
                else if (column == columns - 1)
                {
                    // Otherwise, if we are on the last column row, open the west door
                    currentRoom.doorWest.SetActive(false);
                }
                else
                {
                    // Otherwise, we are in the middle, so open both doors
                    currentRoom.doorEast.SetActive(false);
                    currentRoom.doorWest.SetActive(false);
                }

                grid[column, row] = currentRoom;
                

                temporaryRoom.transform.parent = this.transform;

                temporaryRoom.name = "Room_" + column + "," + row;

            }
        }
    }
}
