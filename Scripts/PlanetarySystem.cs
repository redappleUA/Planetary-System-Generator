using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
{
    /// <summary>
    /// ֳ�� ��� ���������
    /// </summary>
    [SerializeField] private Transform target;
    /// <summary>
    /// �������� ���������
    /// </summary>
    public int speed;
    public static int CountOfPlaneteryObjects { get; set; }

    private static List<IPlanetaryObjects> _planeteryObjects = new();
    /// <summary>
    /// ������ ������
    /// </summary>
    public static List<IPlanetaryObjects> PlaneteryObjects => _planeteryObjects;
    /// <summary>
    /// ����������� ������
    /// </summary>
    /// <param name="totalMass">�������� ����</param>
    /// <param name="i">˳������� � �����, � ����� ����������� ��� �����</param>
    public void Init(ref double totalMass, int i)
    {
        PlanetaryObjects planet = new();
        if (i == CountOfPlaneteryObjects) // ���� ��'��� �������
        {
            if (totalMass > 5000) // ���� ���� �� ��������
            {
                CountOfPlaneteryObjects++;
                PlaneteryObjects.Add(planet);

                planet.mass = Random.Range(0, 5000);
                totalMass -= planet.mass;
            }
            else if (totalMass < 5000)
            {
                PlaneteryObjects.Add(planet);

                planet.mass = totalMass;
            }
        }
        else
        {
            if (totalMass > 5000) // ���� ���� ����� ���� Jovian'�
            {
                PlaneteryObjects.Add(planet);

                planet.mass = Random.Range(0, 5000);
                totalMass -= planet.mass;
            }
            else
            {
                PlaneteryObjects.Add(planet);

                planet.mass = Random.Range(0, (float)totalMass);
                totalMass -= planet.mass;
            }
        }
    }
    void Start()
    {
        if (target == null)
        {
            target = this.gameObject.transform;
            Debug.Log("RotateAround target not specified. Defaulting to parent GameObject");
        }
    }
    void Update()
    {
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }
}