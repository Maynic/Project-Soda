using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetting : MonoBehaviour
{
    [Header("Avatar Mesh Library")] 
    [SerializeField] GameObject[] meshBody = null;
    [SerializeField] GameObject[] meshHair = null;
    [SerializeField] GameObject[] meshFace = null;
    [SerializeField] GameObject[] meshUpper = null;
    [SerializeField] GameObject[] meshLower = null;
    [SerializeField] GameObject[] meshAdd = null;
    [SerializeField] GameObject[] meshGlasses = null;
    [SerializeField] GameObject[] meshBag = null;


    [Header("Selected Index")]
    [Range(0, 3)] [SerializeField] int indexBody = 0;
    [Range(0, 36)] [SerializeField] int indexHair = 0;
    [Range(0, 20)] [SerializeField] int indexFace = 0;
    [Range(0, 35)] [SerializeField] int indexUpper = 0;
    [Range(0, 30)] [SerializeField] int indexLower = 0;

    [Header("Add Parts")]
    [SerializeField] bool isAdd = false;
    [Range(0, 6)] [SerializeField] int indexAdd = 0;
    [SerializeField] bool isGlasses = false;
    [Range(0, 7)] [SerializeField] int indexGlasses = 0;
    [SerializeField] bool isBag = false;
    [Range(0, 9)] [SerializeField] int indexBag = 0;

    [Header("Skin Color (play mode) ")]
    [SerializeField] Color skinColor = Color.white;
    [SerializeField] bool isZombie = false; 

    Material BodyMaterial;
    Material HairMaterial;
    Material FaceMaterial;
    Material UpperMaterial;
    Material LowerMaterial;
    Material AddMaterial;
    Material GlassesMaterial;
    Material BagMaterial;

    int indexBodyMat = 0;
    int indexHairMat = 0;
    int indexFaceMat = 0;
    int indexUpperMat = 0;
    int indexLowerMat = 0;
    int indexAddMat = 0;
    int indexGlassesMat = 0;
    int indexBagMat = 0;

    Color FaceOriginalColor;
    Color BodyOriginalColor;



    // Start is called before the first frame update
    void Start()
    {
        FixIndex();
        SetAvatar();
        SetAvatarColor();

    }

    void FixIndex() //인덱스값이 매쉬 갯수보다 크지 않도록
    {
        indexBodyMat = indexBody;
        indexHairMat = indexHair;
        indexFaceMat = indexFace;
        indexUpperMat = indexUpper;
        indexLowerMat = indexLower;
        indexAddMat = indexAdd;
        indexGlassesMat = indexGlasses;
        indexBagMat = indexBag;

        if (indexBodyMat >= meshBody.Length - 1)
        {
            indexBodyMat = meshBody.Length - 1;
        }
        if (indexHairMat >= meshHair.Length - 1)
        {
            indexHairMat = meshHair.Length - 1;
        }
        if (indexFaceMat >= meshFace.Length - 1)
        {
            indexFaceMat = meshFace.Length - 1;
        }
        if (indexUpperMat >= meshUpper.Length - 1)
        {
            indexUpperMat = meshUpper.Length - 1;
        }
        if (indexLowerMat >= meshLower.Length -1)
        {
            indexLowerMat = meshLower.Length - 1;
        }
        if (indexAddMat >= meshAdd.Length -1)
        {
            indexAddMat = meshAdd.Length - 1;
        }
        if (indexGlassesMat >= meshGlasses.Length - 1)
        {
            indexGlassesMat = meshGlasses.Length - 1;
        }
        if (indexBagMat >= meshBag.Length - 1)
        {
            indexBagMat = meshBag.Length - 1;
        }
    }

    public void SetAvatarColor()
    {
        //for skin color
        BodyMaterial = meshBody[indexBodyMat].GetComponent<Renderer>().material;
        FaceMaterial = meshFace[indexFaceMat].GetComponent<Renderer>().material;

        //for zombie color
        Color zombieColor = new Vector4(0.4f, 0.5f, 0.5f);
        HairMaterial = meshHair[indexHairMat].GetComponent<Renderer>().material;
        UpperMaterial = meshUpper[indexUpperMat].GetComponent<Renderer>().material;
        LowerMaterial = meshLower[indexLowerMat].GetComponent<Renderer>().material;
        AddMaterial = meshAdd[indexAddMat].GetComponent<Renderer>().material;
        GlassesMaterial = meshGlasses[indexGlassesMat].GetComponent<Renderer>().material;
        BagMaterial = meshBag[indexBagMat].GetComponent<Renderer>().material;




        if (isZombie)
        {
            //set eye color
            FaceMaterial.SetColor("_EmissMap", Color.red);
            FaceMaterial.SetFloat("_EmissPow1", 3);

            //set zombie skin color
            FaceMaterial.SetColor("_Tint", skinColor * zombieColor);// = FaceOriginalColor * skinColor;
            BodyMaterial.SetColor("_Tint", skinColor * zombieColor); //= BodyOriginalColor * skinColor;

            //add dirty color
            HairMaterial.SetColor("_Tint", zombieColor);
            UpperMaterial.SetColor("_Tint", zombieColor); 
            LowerMaterial.SetColor("_Tint", zombieColor); 
            AddMaterial.SetColor("_Tint", zombieColor);
            GlassesMaterial.SetColor("_Tint", zombieColor);
            BagMaterial.SetColor("_Tint", zombieColor);
        }
        else
        {
            FaceMaterial.SetColor("_Tint", skinColor);// = FaceOriginalColor * skinColor;
            BodyMaterial.SetColor("_Tint", skinColor); //= BodyOriginalColor * skinColor;
        }
    }


    public void SetAvatar()
    {
        int indexBodyMax = meshBody.Length;
        int indexHairMax = meshHair.Length;
        int indexFaceMax = meshFace.Length;
        int indexUpperMax = meshUpper.Length;
        int indexLowerMax = meshLower.Length;
        int indexAddMax = meshAdd.Length;
        int indexGlassesMax = meshGlasses.Length;
        int indexBagMax = meshBag.Length;

        if (indexBody < indexBodyMax)
        {
            for (int i = 0; i < indexBodyMax; i++)
            {
                meshBody[i].gameObject.SetActive(false);
            }
            meshBody[indexBody].gameObject.SetActive(true);
        }

        // set avatar mesh
        if (indexHair < indexHairMax)
        {
            for (int i = 0; i < indexHairMax; i++)
            {
                meshHair[i].gameObject.SetActive(false);
            }
            meshHair[indexHair].gameObject.SetActive(true);
        }

        if (indexFace < indexFaceMax )
        {
            for (int i = 0; i < indexFaceMax; i++)
            {
                meshFace[i].gameObject.SetActive(false);
            }
            meshFace[indexFace].gameObject.SetActive(true);
        }
        if (indexUpper < indexUpperMax)
        {
            for (int i = 0; i < indexUpperMax; i++)
            {
                meshUpper[i].gameObject.SetActive(false);
            }
            meshUpper[indexUpper].gameObject.SetActive(true);
        }
        if (indexLower < indexLowerMax)
        {
            for (int i = 0; i < indexLowerMax; i++)
            {
                meshLower[i].gameObject.SetActive(false);
            }
            meshLower[indexLower].gameObject.SetActive(true);
        }



        //체크박스가 필요한 파츠들 비활성화
        if (indexAdd < indexAddMax)
        {
            for (int i = 0; i < indexAddMax; i++)
            {
                meshAdd[i].gameObject.SetActive(false);
            }
        }
        if (indexGlasses < indexGlassesMax)
        {
            for (int i = 0; i < indexGlassesMax; i++)
            {
                meshGlasses[i].gameObject.SetActive(false);
            }
        }
        if (indexBag < indexBagMax)
        {
            for (int i = 0; i < indexBagMax; i++)
            {
                meshBag[i].gameObject.SetActive(false);
            }
        }

        //체크박스 체크 시 활성화 
        if (isAdd)
        {
            if (indexAdd < indexAddMax)
            {
                meshAdd[indexAdd].gameObject.SetActive(true);
            }
        }
        if (isGlasses)
        {
            if (indexGlasses < indexGlassesMax)
            {
                meshGlasses[indexGlasses].gameObject.SetActive(true);
            }
        }
        if (isBag)
        {
            if (indexBag < indexBagMax)
            {
                meshBag[indexBag].gameObject.SetActive(true);
            }
        }
    }

    
}
