# MeshRenderer #
A Windows Forms application built with .NET 8.0 that visualizes a Bézier surface defined by 16 control points. This interactive renderer allows you to customize surface appearance and lighting, adjust triangulation fidelity, and rotate the surface—all while using a robust scanline algorithm with an Active Edge Table (AET) and z-buffer for efficient hidden surface removal.

## Features ##
- ### Bézier Surface Visualization ###
    - Loads 16 control points to display a smooth Bézier surface.
    
    - **Control Points File Format:** The file must be a `.txt` file where each line contains 3 space-separated float values representing the x, y, and z coordinates. Floats must use a dot (`.`) as the decimal separator. At least 16 points are required to load a mesh.

- ### Customizable Surface Appearance ###
    - **Surface Color:** Choose the primary color for the surface.

    - **Texture & Normal Map:** Apply a texture and a normal map to enhance surface details.

- ### Lighting Options ###
    - **Light Color:** Select the color of the light source.

    - **Lambert Model with Specular Component:** Utilize a lighting model that combines Lambertian diffuse reflection with a specular highlight

    - **Adjustable Lighting Parameters:** Modify the diffuse coefficient (kd), specular coefficient (ks), and the specular exponent (m).

    - **Light Source Control:** Change the height of the light source or activate a periodic spiral movement to dynamically animate the lighting.

- ### Surface and Triangulation Controls ###
    - **Triangulation Fidelity:** Adjust the fidelity of the triangulation used to render the surface.

    - **Rotation:** Rotate the surface to view it from different angles.

- ### Rendering ###
    - Implements a scanline algorithm enhanced with an Active Edge Table (AET) and a z-buffer for accurate and efficient rendering.

- ### Example Scene ###
    - When the app starts, an example scene is automatically loaded, showcasing a sample Bézier surface