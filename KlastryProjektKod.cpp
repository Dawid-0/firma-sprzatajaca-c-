#include <iostream>
#include <cstdio>
#include <vector>
#include <algorithm>
#include <cmath>
#include <mpi.h>

using namespace std;

int main(int argc, char** argv) {
    MPI_Init(&argc, &argv);

    int numer_procesu, lprocesow;
    MPI_Comm_rank(MPI_COMM_WORLD, &numer_procesu);
    MPI_Comm_size(MPI_COMM_WORLD, &lprocesow);

    vector<double> dane;
    int wmin;
    double szer_kub;

    if (numer_procesu == 0) {
        dane = { 102.4, -165.0, 507.1, -9.0, -42.0, 
                 167.0, -564.5, -673.0, 321.3, -641.4,
                -303.4,  337.8, -918.7, -235.1, 294.0, 
                 203.9, -846.2,  60.3,  206.3, -698.5 };

        printf("Przed sortowaniem:\n");
        for (double liczba : dane) printf("%.1f ", liczba);
        printf("\n\n");

        double min_val = *min_element(dane.begin(), dane.end());
        double max_val = *max_element(dane.begin(), dane.end());

        wmin = static_cast<int>(floor(min_val));
        szer_kub = (max_val - wmin) / lprocesow;
        if (szer_kub == 0) szer_kub = 1.0;
    }

    MPI_Bcast(&wmin, 1, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Bcast(&szer_kub, 1, MPI_DOUBLE, 0, MPI_COMM_WORLD);

    vector<double> moj_kubelek;

    if (numer_procesu == 0) {
        vector<vector<double>> kubelki(lprocesow);
        
        printf("Przydzielanie do kubelkow\n");
        for (double liczba : dane) {
            int nr_kubelka = (liczba - wmin) / szer_kub;
            if (nr_kubelka >= lprocesow) nr_kubelka = lprocesow - 1; 

            if (nr_kubelka == 0 && lprocesow > 1) {
                nr_kubelka = 1;
            }

            printf("Liczba %.1f trafia do kubełka nr: %d\n", liczba, nr_kubelka);
            kubelki[nr_kubelka].push_back(liczba);
        }
 

        moj_kubelek = kubelki[0];

        for (int i = 1; i < lprocesow; i++) {
            int ile = kubelki[i].size();
            MPI_Send(&ile, 1, MPI_INT, i, 0, MPI_COMM_WORLD);
            if (ile > 0) {
                MPI_Send(kubelki[i].data(), ile, MPI_DOUBLE, i, 0, MPI_COMM_WORLD);
            }
        }
    } 

    else {
        int ile;
        MPI_Recv(&ile, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        if (ile > 0) {
            moj_kubelek.resize(ile);
            MPI_Recv(moj_kubelek.data(), ile, MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        }
    }

    sort(moj_kubelek.begin(), moj_kubelek.end());

    if (numer_procesu != 0) {
        int ile = moj_kubelek.size();
        MPI_Send(&ile, 1, MPI_INT, 0, 1, MPI_COMM_WORLD);
        if (ile > 0) {
            MPI_Send(moj_kubelek.data(), ile, MPI_DOUBLE, 0, 1, MPI_COMM_WORLD);
        }
    } 

    else {
        int pozycja = 0;


        for (double liczba : moj_kubelek) {
            dane[pozycja++] = liczba;
        }

        for (int i = 1; i < lprocesow; i++) {
            int ile;
            MPI_Recv(&ile, 1, MPI_INT, i, 1, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
            if (ile > 0) {
                vector<double> odebrane(ile);
                MPI_Recv(odebrane.data(), ile, MPI_DOUBLE, i, 1, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
                for (double liczba : odebrane) {
                    dane[pozycja++] = liczba;
                }
            }
        }

        printf("Po sortowaniu:\n");
        for (double liczba : dane) printf("%.1f ", liczba);
        printf("\n");
    }

    MPI_Finalize();
    return 0;
}