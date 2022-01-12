import pygame as pg
import sys

def checkIntersection(Walls, Ray):
    #Reset List to default Rayfactor
    List = [1000]
    #Check the Intersection Point with every Wall (Analytische Geometrie)
    for Wall in Walls:
        WallZaehler = Ray.DirectionVector[0]*(Wall.p1[1]-Ray.OrtsVektor[1]) + Ray.DirectionVector[1]*(Ray.OrtsVektor[0]-Wall.p1[0])
        WallNenner = (Wall.p2[0]-Wall.p1[0])*Ray.DirectionVector[1] - (Wall.p2[1]-Wall.p1[1])*Ray.DirectionVector[0]
        try:
             WallIntersectionParameter = WallZaehler/WallNenner
        except ZeroDivisionError:
             WallIntersectionParameter = WallZaehler/0.001
     #If Intersection Point valid for physical Intersection get the Ray Intersection point
        if WallIntersectionParameter > 0 and WallIntersectionParameter <= 1:
            try:
                RayIntersection = (Wall.p1[0]+(Wall.p2[0]-Wall.p1[0])*WallIntersectionParameter-Ray.OrtsVektor[0])/Ray.DirectionVector[0]
            except ZeroDivisionError:
                RayIntersection = (Wall.p1[0]+(Wall.p2[0]-Wall.p1[0])*WallIntersectionParameter-Ray.OrtsVektor[0])/0.001
            if RayIntersection > 0:
                # Add RayIntersection point to list
                if RayIntersection in List:
                    pass
                else:
                    List.append(RayIntersection)
    # New rayfactor is smallest rayintersectionpoint
    Ray.factor = min(List)